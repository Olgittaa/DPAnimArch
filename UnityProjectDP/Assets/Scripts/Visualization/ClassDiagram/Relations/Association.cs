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
    }
}
