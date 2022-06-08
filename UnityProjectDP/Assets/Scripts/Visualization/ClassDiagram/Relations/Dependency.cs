using System;
using AnimArch.Visualization.Diagrams;
using OALProgramControl;

namespace Assets.Scripts.Visualization.ClassDiagram
{
    public class Dependency : AbstractRelation
    {
        public Dependency(Relation relation)
        {
            RelationInfo = OALProgram.Instance.RelationshipSpace.SpawnRelationship(relation.FromClass, relation.ToClass);
            relation.OALName = RelationInfo.RelationshipName;
            relation.PrefabType = DiagramPool.Instance.dependsPrefab;

            XMIParsedRelation = relation;
        }
    }
}
