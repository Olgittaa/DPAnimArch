using System.Collections.Generic;

namespace OALProgramControl
{
    public class NullScope : EXEAbstractScope
    {
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

        protected override bool Execute(OALProgram OALProgram)
        {
            return false;
        }
    }
}