using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OALProgramControl
{
    public abstract class EXECommandQuerrySelectAbstract : EXECommand
    {
        public const String CardinalityAny = "any";
        public const String CardinalityMany = "many";
        public String Cardinality { get; set; }
        public String VariableName { get; set; }
        public EXEASTNode WhereCondition { get; set; }

        protected OALProgram OalProgram;
        protected abstract bool VariableNameExists();
        protected abstract List<long> EvaluateRelationshipSelection();
        protected abstract EXEReferencingVariable GetEXEReferencingVariable(String name);
        protected abstract EXEReferencingVariable GetEXEReferencingVariable(long ResultId);
        protected abstract EXEReferencingSetVariable GetEXEReferencingSetVariable();
        protected bool EvaluateCondition(List<long> SelectedIds)
        {
            if (this.WhereCondition != null && SelectedIds.Any())
            {
                String TempSelectedVarName = "selected";

                EXEReferencingVariable SelectedVar = GetEXEReferencingVariable(TempSelectedVarName);
                if (!SuperScope.AddVariable(SelectedVar))
                {
                    return false;
                }

                List<long> ResultIds = new List<long>();
                foreach (long Id in SelectedIds)
                {
                    //Console.WriteLine("id check iteration start");
                    SelectedVar.ReferencedInstanceId = Id;
                    String ConditionResult = this.WhereCondition.Evaluate(SuperScope, OalProgram.ExecutionSpace);

                    if (!EXETypes.IsValidValue(ConditionResult, EXETypes.BooleanTypeName))
                    {
                        SuperScope.DestroyReferencingVariable(TempSelectedVarName);
                        return false;
                    }

                    if (EXETypes.BooleanTrue.Equals(ConditionResult))
                    {
                        ResultIds.Add(Id);
                    }
                }
                SelectedIds = ResultIds;
                SuperScope.DestroyReferencingVariable(TempSelectedVarName);
                return true;
            }
            return false;
        }
        protected override bool Execute(OALProgram OALProgram)
        {
            Debug.Log("EXE from AbstractSelect");
            OalProgram = OALProgram;
            // We need to check, if the variable already exists, it must be of corresponding type
            if (!VariableNameExists())
            {
                return false;
            }
            List<long> SelectedIds = EvaluateRelationshipSelection();
            if (SelectedIds == null)
            {
                return false;
            }

            // If class has no instances, command may execute successfully, but we better verify references in the WHERE condition
            if (SelectedIds.Count() == 0 && this.WhereCondition != null)
            {
                return this.WhereCondition.VerifyReferences(SuperScope, OALProgram.ExecutionSpace);
            }

            // Now let's evaluate the condition
            if (!EvaluateCondition(SelectedIds))
            {
                return false;
            }

            if (CardinalityMany.Equals(Cardinality))
            {
                EXEReferencingSetVariable Variable = SuperScope.FindSetReferencingVariableByName(VariableName);
                if (Variable == null)
                {
                    Variable = GetEXEReferencingSetVariable();
                    if (!SuperScope.AddVariable(Variable))
                    {
                        return false;
                    }
                }
                foreach (long Id in SelectedIds)
                {
                    Variable.AddReferencingVariable(new EXEReferencingVariable("", Variable.ClassName, Id));
                }
            }
            else if (CardinalityAny.Equals(Cardinality))
            {
                EXEReferencingVariable Variable = SuperScope.FindReferencingVariableByName(VariableName);
                long ResultId = SelectedIds.Any() ? SelectedIds[new System.Random().Next(SelectedIds.Count)] : -1;
                if (Variable == null)
                {
                    Variable = GetEXEReferencingVariable(ResultId);
                    if (!SuperScope.AddVariable(Variable))
                    {
                        return false;
                    }
                }
                else
                {
                    Variable.ReferencedInstanceId = ResultId; // only QuerrySelect, not related by?
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
