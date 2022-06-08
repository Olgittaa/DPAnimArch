using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OALProgramControl
{
    public class EXECommandQuerySelectRelatedBy : EXECommandQuerrySelectAbstract
    {
        public EXERelationshipSelection RelationshipSelection {get; set;}

        public EXECommandQuerySelectRelatedBy(String Cardinality, String VariableName, EXEASTNode WhereCondition, EXERelationshipSelection RelationshipSelection)
        {
            this.Cardinality = Cardinality;
            this.VariableName = VariableName;
            this.WhereCondition = WhereCondition;
            this.RelationshipSelection = RelationshipSelection;
        }
        protected override bool VariableNameExists()
        {
            if (this.RelationshipSelection == null)
            {
                return false;
            }

            if (SuperScope.VariableNameExists(this.VariableName))
            {
                if (!((CardinalityAny.Equals(Cardinality) && RelationshipSelection.GetLastClassName() == SuperScope.FindReferencingVariableByName(VariableName).ClassName)
                    || (CardinalityMany.Equals(Cardinality) && RelationshipSelection.GetLastClassName() == SuperScope.FindSetReferencingVariableByName(VariableName).ClassName)))
                {
                    return false;
                }
            }
            return true;
        }
        protected override List<long> EvaluateRelationshipSelection()
        {
            CDClass Class = OalProgram.ExecutionSpace.getClassByName(this.RelationshipSelection.GetLastClassName());
            if (Class == null)
            {
                return null;
            }
            List<long> SelectedIds = this.RelationshipSelection.Evaluate(OalProgram.RelationshipSpace, (EXEScope)SuperScope);
            return SelectedIds;
        }
        protected override EXEReferencingVariable GetEXEReferencingVariable(string name)
        {
            return new EXEReferencingVariable(name, RelationshipSelection.GetLastClassName(), -1);

        }
        protected override EXEReferencingVariable GetEXEReferencingVariable(long ResultId)
        {
            return new EXEReferencingVariable(VariableName, RelationshipSelection.GetLastClassName(), ResultId);
        }
        protected override EXEReferencingSetVariable GetEXEReferencingSetVariable()
        {
            return new EXEReferencingSetVariable(VariableName, RelationshipSelection.GetLastClassName());
        }
        public override string ToCodeSimple()
        {
            string prefix = "select " + this.Cardinality + " " + this.VariableName + " related by ";
            string relationLink = this.RelationshipSelection.ToCode();
            string sufix = this.WhereCondition == null ? "" : (" where ") + this.WhereCondition.ToCode();
            return prefix + relationLink + sufix;
        }
    }
}
