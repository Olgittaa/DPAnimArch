using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OALProgramControl
{
    public class EXECommandQuerySelect : EXECommandQuerrySelectAbstract
    {
        public String ClassName { get; set; }
        public EXECommandQuerySelect(String Cardinality, String ClassName, String VariableName)
        {
            this.Cardinality = Cardinality;
            this.ClassName = ClassName;
            this.VariableName = VariableName;
            this.WhereCondition = null;
        }
        public EXECommandQuerySelect(String Cardinality, String ClassName, String VariableName, EXEASTNode WhereCondition)
        {
            this.Cardinality = Cardinality;
            this.ClassName = ClassName;
            this.VariableName = VariableName;
            this.WhereCondition = WhereCondition;
        }
        protected override bool VariableNameExists()
        {
            if (SuperScope.VariableNameExists(VariableName))
            {
                if (!((CardinalityAny.Equals(Cardinality) && ClassName == SuperScope.FindReferencingVariableByName(VariableName).ClassName)
                    || (CardinalityMany.Equals(Cardinality) && ClassName == SuperScope.FindSetReferencingVariableByName(VariableName).ClassName)))
                {
                    return false;
                }
            }
            return true;
        }
        protected override List<long> EvaluateRelationshipSelection()
        {
            CDClass Class = OalProgram.ExecutionSpace.getClassByName(this.ClassName);
            if (Class == null)
            {
                return null;
            }
            List<long> SelectedIds = Class.GetAllInstanceIDs();
            return SelectedIds;
        }
        protected override EXEReferencingVariable GetEXEReferencingVariable(String name)
        {
            return new EXEReferencingVariable(name, this.ClassName, -1);
        }
        protected override EXEReferencingVariable GetEXEReferencingVariable(long ResultId)
        {
            return new EXEReferencingVariable(this.VariableName, this.ClassName, ResultId);
        }
        protected override EXEReferencingSetVariable GetEXEReferencingSetVariable()
        {
            return new EXEReferencingSetVariable(this.VariableName, this.ClassName);
        }
        public override string ToCodeSimple()
        {
            return "select " + this.Cardinality + " " + this.VariableName + " from instances of " + this.ClassName +
                (this.WhereCondition == null ? "" : (" where ") + this.WhereCondition.ToCode());
        }
    }
}
