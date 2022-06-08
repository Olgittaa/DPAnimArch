using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimArch.Visualization.Diagrams;

namespace Assets.Scripts.Visualization.ClassDiagram
{
    public class RelationFactory : Singleton<RelationFactory>
    {
        public AbstractRelation CreateRelation(Relation relation, String relationType)
        {
            switch (relationType)
            {
                case "Association": return new Association(relation);
                case "Generalization": return new Generalization(relation);
                case "Dependency": return new Dependency(relation);
                case "Realisation": return new Realisation(relation);
                default: return new Association(relation);
            }
        }
    }
}
