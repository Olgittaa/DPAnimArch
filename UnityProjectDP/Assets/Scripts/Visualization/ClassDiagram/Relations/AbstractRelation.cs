using AnimArch.Visualization.Diagrams;
using OALProgramControl;
using UnityEngine;

namespace Assets.Scripts.Visualization.ClassDiagram
{
    public abstract class AbstractRelation
    {
        public Relation XMIParsedRelation;
        public CDRelationship RelationInfo;
        public GameObject VisualObject;
    }
}
