using System;
using System.Collections.Generic;

namespace OALProgramControl
{
    public abstract class EXEAbstractScope : EXECommand
    {
        public List<EXEPrimitiveVariable> PrimitiveVariables;
        public List<EXEReferencingVariable> ReferencingVariables;
        public List<EXEReferencingSetVariable> SetReferencingVariables;
        public abstract Dictionary<string, string> GetAllHandleStateAttrsDictRecursive(CDClassPool executionSpace);
        public abstract EXEPrimitiveVariable FindPrimitiveVariableByName(string name);
        public abstract bool UnsetReferencingVariables(string className, long instanceId);
        public abstract int ValidVariableReferencingCountRecursive();
        public abstract IEnumerable<(string, string)> GetReferencingVariablesByIDRecursive(long id);
        public abstract bool AddVariable(EXEPrimitiveVariable exePrimitiveVariable);
        public abstract EXEReferencingVariable FindReferencingVariableByName(string instanceName);
        public abstract bool AddVariable(EXEReferencingVariable exePrimitiveVariable);
        public abstract bool DestroyReferencingVariable(string tempSelectedVarName);
        public abstract EXEReferencingSetVariable FindSetReferencingVariableByName(string variableName);
        public abstract bool VariableNameExists(string variableName);
        public abstract EXEReferenceHandle FindReferenceHandleByName(string startingVariable);
        public abstract bool AddVariable(EXEReferencingSetVariable exePrimitiveVariable);
    }
}