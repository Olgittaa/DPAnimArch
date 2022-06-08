using System;
using AnimArch.Visualization.Diagrams;
using OALProgramControl;

namespace Assets.Scripts.Visualization.ClassDiagram
{
    public class Generalization : AbstractRelation
    {
        public Generalization(String fromClass, String toClass)
        {
            RelationInfo = OALProgram.Instance.RelationshipSpace.SpawnRelationship(fromClass, toClass);
            XMIParsedRelation.OALName = RelationInfo.RelationshipName;
            XMIParsedRelation.PrefabType = DiagramPool.Instance.generalizationPrefab;
        }

        public Generalization(Relation relation)
        {
            RelationInfo = OALProgram.Instance.RelationshipSpace.SpawnRelationship(relation.FromClass, relation.ToClass);
            relation.OALName = RelationInfo.RelationshipName;
            relation.PrefabType = DiagramPool.Instance.generalizationPrefab;
            XMIParsedRelation = relation;
        }
    }
}
