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
        public AbstractRelation CreateRelation(String fromClass, String toClass, String relationType, String direction)
        {
            switch(relationType)
            {
                case "Association": return new Association(fromClass, toClass, direction);
                case "Generalization": return new Generalization(fromClass, toClass);
                case "Dependency": return new Dependency(fromClass, toClass);
                case "Realisation": return new Realisation(fromClass, toClass);
                default: return new Association(fromClass, toClass, "");
            }
        }
    }
}
