using System.Collections.Generic;
using OALProgramControl.Visitor;

namespace OALProgramControl
{
    public class NullScope : EXEAbstractScope
    {
        private static NullScope _instance;

        private NullScope()
        {
        }

        public static NullScope Instance
        {
            get
            {
                if (_instance == null)
                    return new NullScope();
                return _instance;
            }
        }

        public override EXEPrimitiveVariable FindPrimitiveVariableByName(string Name)
        {
            return null;
        }

        public override Dictionary<string, string> GetAllHandleStateAttrsDictRecursive(CDClassPool ExecutionSpace)
        {
            return new Dictionary<string, string>();
        }

        public override bool UnsetReferencingVariables(string ClassName, long InstanceID)
        {
            return false;
        }

        public override int ValidVariableReferencingCountRecursive()
        {
            return 0;
        }

        public override List<(string, string)> GetReferencingVariablesByIDRecursive(long ID)
        {
            return null;
        }

        public override bool AddVariable(EXEReferencingVariable iteratorVariable)
        {
            return false;
        }

        public override EXEReferencingSetVariable FindSetReferencingVariableByName(string value)
        {
            throw new System.NotImplementedException();
        }

        public override EXEReferencingVariable FindReferencingVariableByName(string value)
        {
            throw new System.NotImplementedException();
        }

        public override bool VariableNameExists(string variableName)
        {
            throw new System.NotImplementedException();
        }

        public override bool DestroyReferencingVariable(string tempSelectedVarName)
        {
            throw new System.NotImplementedException();
        }

        public override bool AddVariable(EXEReferencingSetVariable iteratorVariable)
        {
            throw new System.NotImplementedException();
        }

        public override EXEReferenceHandle FindReferenceHandleByName(string startingVariable)
        {
            throw new System.NotImplementedException();
        }

        public override bool AddVariable(EXEPrimitiveVariable iteratorVariable)
        {
            throw new System.NotImplementedException();
        }

        public override void Accept(IConvertToCodeVisitor visitor)
        {
            visitor.VisitScope(this);
        }

        protected override bool Execute(OALProgram OALProgram)
        {
            return false;
        }
    }
}