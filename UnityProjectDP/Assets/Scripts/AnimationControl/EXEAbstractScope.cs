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
        public abstract bool AddVariable(EXEReferencingVariable iteratorVariable);
        public abstract EXEReferencingSetVariable FindSetReferencingVariableByName(string value);
        public abstract EXEReferencingVariable FindReferencingVariableByName(string value);
        public abstract bool VariableNameExists(string variableName);
        public abstract bool DestroyReferencingVariable(string tempSelectedVarName);
        public abstract bool AddVariable(EXEReferencingSetVariable iteratorVariable);
        public abstract EXEReferenceHandle FindReferenceHandleByName(string startingVariable);
        public abstract bool AddVariable(EXEPrimitiveVariable iteratorVariable);
    }
}