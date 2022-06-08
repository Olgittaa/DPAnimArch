using System;
using System.Collections.Generic;
using OALProgramControl.Visitor;

namespace OALProgramControl
{
    public class EXENullScope : EXEAbstractScope
    {
        private static EXENullScope _instance;

        private EXENullScope()
        {
        }

        public static EXENullScope Instance
        {
            get
            {
                if (_instance == null)
                    return new EXENullScope();
                return _instance;
            }
        }

        public override void Accept(IConvertToCodeVisitor visitor)
        {
            return;
        }

        protected override bool Execute(OALProgram OALProgram)
        {
            return false;
        }

        public override Dictionary<string, string> GetAllHandleStateAttrsDictRecursive(CDClassPool executionSpace)
        {
            return null;
        }

        public override EXEPrimitiveVariable FindPrimitiveVariableByName(string name)
        {
            return null;
        }

        public override bool UnsetReferencingVariables(string className, long instanceId)
        {
            return false;
        }

        public override int ValidVariableReferencingCountRecursive()
        {
            return 0;
        }

        public override IEnumerable<(string, string)> GetReferencingVariablesByIDRecursive(long id)
        {
            return null;
        }

        public override bool AddVariable(EXEPrimitiveVariable exePrimitiveVariable)
        {
            return false;
        }

        public override EXEReferencingVariable FindReferencingVariableByName(string instanceName)
        {
            return null;
        }

        public override bool AddVariable(EXEReferencingVariable exePrimitiveVariable)
        {
            return false;
        }

        public override bool DestroyReferencingVariable(string tempSelectedVarName)
        {
            return false;
        }

        public override EXEReferencingSetVariable FindSetReferencingVariableByName(string variableName)
        {
            return null;
        }

        public override bool VariableNameExists(string variableName)
        {
            return false;
        }

        public override EXEReferenceHandle FindReferenceHandleByName(string startingVariable)
        {
            return null;
        }

        public override bool AddVariable(EXEReferencingSetVariable exePrimitiveVariable)
        {
            return false;
        }
    }
}