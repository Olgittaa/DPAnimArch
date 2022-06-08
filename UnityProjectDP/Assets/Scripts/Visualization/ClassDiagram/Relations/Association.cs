using System;
using AnimArch.Visualization.Diagrams;
using OALProgramControl;

namespace Assets.Scripts.Visualization.ClassDiagram
{
    public class Association : AbstractRelation
    {
        public Association(String fromClass, String toClass, String direction)
        {
            RelationInfo = OALProgram.Instance.RelationshipSpace.SpawnRelationship(fromClass, toClass);
            XMIParsedRelation.OALName = RelationInfo.RelationshipName;
            switch (direction)
            {
                case "Source -> Destination": XMIParsedRelation.PrefabType = DiagramPool.Instance.associationSDPrefab; break;
                case "Destination -> Source": XMIParsedRelation.PrefabType = DiagramPool.Instance.associationDSPrefab; break;
                case "Bi-Directional": XMIParsedRelation.PrefabType = DiagramPool.Instance.associationFullPrefab; break;
                default: XMIParsedRelation.PrefabType = DiagramPool.Instance.associationNonePrefab; break;
            }
        }

        public Association(Relation relation)
        {
            RelationInfo = OALProgram.Instance.RelationshipSpace.SpawnRelationship(relation.FromClass, relation.ToClass);
            relation.OALName = RelationInfo.RelationshipName;
            switch (relation.ProperitesDirection)
            {
                case "Source -> Destination": relation.PrefabType = DiagramPool.Instance.associationSDPrefab; break;
                case "Destination -> Source": relation.PrefabType = DiagramPool.Instance.associationDSPrefab; break;
                case "Bi-Directional": relation.PrefabType = DiagramPool.Instance.associationFullPrefab; break;
                default: relation.PrefabType = DiagramPool.Instance.associationNonePrefab; break;
            }

            relation.OALName = RelationInfo.RelationshipName;
            relation.PrefabType = DiagramPool.Instance.generalizationPrefab;
            XMIParsedRelation = relation;
        }
    }
}
