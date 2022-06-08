using System;
using System.Collections.Generic;

namespace OALProgramControl
{
    public abstract class EXEAbstractScope : EXECommand
    {
        public List<EXEPrimitiveVariable> PrimitiveVariables;
        public List<EXEReferencingVariable> ReferencingVariables;
        public List<EXEReferencingSetVariable> SetReferencingVariables;
        public abstract EXEPrimitiveVariable FindPrimitiveVariableByName(String Name);
        public abstract Dictionary<string, string> GetAllHandleStateAttrsDictRecursive(CDClassPool ExecutionSpace);
        public abstract bool UnsetReferencingVariables(string ClassName, long InstanceID);
        public abstract int ValidVariableReferencingCountRecursive();
        public abstract List<(string, string)> GetReferencingVariablesByIDRecursive(long ID);
        public abstract void SetSuperScope(EXEScope SuperScope);

        public abstract bool VariableNameExists(String VariableName);
        public abstract EXEReferencingSetVariable FindSetReferencingVariableByName(String Name);
        public abstract bool AddVariable(EXEReferencingSetVariable Variable);

        public abstract Boolean DestroyReferencingVariable(String VariableName);


        public abstract bool AddVariable(EXEPrimitiveVariable Variable);
        public abstract bool AddVariable(EXEReferencingVariable Variable);
        public abstract EXEReferencingVariable FindReferencingVariableByName(String Name);
    }
}