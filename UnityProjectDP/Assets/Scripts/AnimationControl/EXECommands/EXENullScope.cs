using System;
using System.Collections.Generic;

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

        public override void SetSuperScope(EXEScope SuperScope) { }

        public override EXEReferencingVariable FindReferencingVariableByName(String Name)
        {
            return null;
        }
        public override bool VariableNameExists(String VariableName)
        {
            return false;
        }

        public override EXEReferencingSetVariable FindSetReferencingVariableByName(String Name)
        {
            return null;
        }

        public override Boolean DestroyReferencingVariable(String VariableName)
        {
            return false;
        }

        public override bool AddVariable(EXEReferencingSetVariable Variable)
        {
            return false;
        }

        public override bool AddVariable(EXEPrimitiveVariable Variable)
        {
            return false;
        }
        public override bool AddVariable(EXEReferencingVariable Variable)
        {
            return false;
        }

        protected override bool Execute(OALProgram OALProgram)
        {
            return false;
        }
    }
}