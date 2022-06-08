﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace OALProgramControl
{
    public class EXECommandCall : EXECommand
    {
        private String CalledClass { get; set; }
        private String CalledMethod { get; }
        private String InstanceName { get; }
        private String AttributeName { get; }
        private List<EXEASTNode> Parameters { get; }
        private MethodCallRecord CallerMethodInfo
        {
            get
            {
                EXEScopeMethod TopScope = (EXEScopeMethod)GetTopLevelScope();
                return TopScope.MethodDefinition;
            }
        }

        public EXECommandCall(String InstanceName, String AttributeName, String MethodName, List<EXEASTNode> Parameters)
        {
            this.InstanceName = InstanceName;
            this.AttributeName = AttributeName;
            this.CalledMethod = MethodName;
            this.Parameters = Parameters;
        }

        protected override Boolean Execute(OALProgram OALProgram)
        {
            EXEReferencingVariable Reference = this.SuperScope.FindReferencingVariableByName(this.InstanceName);

            if (Reference == null)
            {
                return false;
            }

            CDClass Class = OALProgram.ExecutionSpace.getClassByName(Reference.ClassName);

            if (Class == null)
            {
                return false;
            }

            if (this.AttributeName != null)
            {
                CDAttribute Attribute = Class.GetAttributeByName(this.AttributeName);

                if (Attribute == null)
                {
                    return false;
                }

                CDClass AtrributeClass = OALProgram.ExecutionSpace.getClassByName(Attribute.Type);

                if (AtrributeClass == null)
                {
                    return false;
                }

                Class = AtrributeClass;
            }

            this.CalledClass = Class.Name;

            CDMethod Method = Class.getMethodByName(this.CalledMethod);

            if (Method == null)
            {
                return false;
            }

            EXEScopeMethod MethodCode = Method.ExecutableCode;

            if (MethodCode == null)
            {
                return true;
            }

            MethodCode.SetSuperScope(null);
            OALProgram.CommandStack.Enqueue(MethodCode);

            for (int i = 0; i < this.Parameters.Count; i++)
            {
                CDParameter Parameter = Method.Parameters[i];

                if (EXETypes.IsPrimitive(Parameter.Type))
                {
                    String Value = Parameters[i].Evaluate(this.SuperScope, OALProgram.ExecutionSpace);

                    if (!EXETypes.IsValidValue(Value, Parameter.Type))
                    {
                        return false;
                    }

                    MethodCode.AddVariable(new EXEPrimitiveVariable(Parameter.Name, Value));
                }
                else if ("[]".Equals(Parameter.Type.Substring(Parameter.Type.Length - 2, 2)))
                {
                    CDClass ClassDefinition = OALProgram.ExecutionSpace.getClassByName(Parameter.Type.Substring(0, Parameter.Type.Length - 2));
                    if (ClassDefinition == null)
                    {
                        return false;
                    }
                    //co ak value je integer napr. 5 a nie id, zistime to? netreba parsovat aj do long ?
                    String Values = Parameters[i].Evaluate(this.SuperScope, OALProgram.ExecutionSpace);

                    if (!EXETypes.IsValidReferenceValue(Values, Parameter.Type))
                    {
                        return false;
                    }

                    int[] IDs = Values.Split(',').Select(id => int.Parse(id)).ToArray();

                    CDClassInstance ClassInstance;
                    foreach (int ID in IDs)
                    {
                        ClassInstance = ClassDefinition.GetInstanceByID(ID);
                        if (ClassInstance == null)
                        {
                            return false;
                        }
                    }

                    EXEReferencingSetVariable CreatedSetVariable = new EXEReferencingSetVariable(Parameter.Name, ClassDefinition.Name);

                    foreach (int ID in IDs)
                    {
                        CreatedSetVariable.AddReferencingVariable(new EXEReferencingVariable("", ClassDefinition.Name, ID));
                    }

                    MethodCode.AddVariable(CreatedSetVariable);
                }
                else if (!String.IsNullOrEmpty(Parameter.Type))
                {
                    CDClass ClassDefinition = OALProgram.ExecutionSpace.getClassByName(Parameter.Type);
                    if (ClassDefinition == null)
                    {
                        return false;
                    }
                    //co ak value je integer napr. 5 a nie id, zistime to? netreba parsovat aj do long ?
                    String Value = Parameters[i].Evaluate(this.SuperScope, OALProgram.ExecutionSpace);

                    if (!EXETypes.IsValidReferenceValue(Value, Parameter.Type))
                    {
                        return false;
                    }

                    int ID = int.Parse(Value);

                    CDClassInstance ClassInstance = ClassDefinition.GetInstanceByID(ID);
                    if (ClassInstance == null)
                    {
                        return false;
                    }

                    MethodCode.AddVariable(new EXEReferencingVariable(Parameter.Name, ClassDefinition.Name, ID));
                }
            }

            return true;
        }

        public OALCall CreateOALCall()
        {
            MethodCallRecord _CallerMethodInfo = this.CallerMethodInfo;
            CDRelationship _RelationshipInfo = CallRelationshipInfo(_CallerMethodInfo.ClassName, this.CalledClass);
            return new OALCall
            (
                _CallerMethodInfo.ClassName,
                _CallerMethodInfo.MethodName,
                _RelationshipInfo.RelationshipName,
                this.CalledClass,
                this.CalledMethod
            );
        }

        public override String ToCodeSimple()
        {
            MethodCallRecord _CallerMethodInfo = this.CallerMethodInfo;
            CDRelationship _RelationshipInfo = CallRelationshipInfo(_CallerMethodInfo.ClassName, this.CalledClass);
            return "call from " + _CallerMethodInfo.ClassName + "::" + _CallerMethodInfo.MethodName + "() to "
                + this.CalledClass + "::" + this.CalledMethod + "() across " + _RelationshipInfo.RelationshipName;
        }

        private CDRelationship CallRelationshipInfo(string CallerMethod, string CalledMethod)
        {
            return OALProgram.Instance.RelationshipSpace.GetRelationshipByClasses(CallerMethod, CalledMethod);
        }
    }
}
