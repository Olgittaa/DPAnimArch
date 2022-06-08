using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AnimArch.Visualization.Diagrams
{
    public abstract class Diagram : MonoBehaviour
    {
        protected static GameObject CreateInterGraphLine(GameObject start, GameObject end)
        {
            GameObject Line = Instantiate(DiagramPool.Instance.interGraphLinePrefab);

            Line.GetComponent<LineRenderer>().SetPositions
            (
                new Vector3[]
                {
                    start.GetComponent<RectTransform>().position,
                    end.GetComponent<RectTransform>().position
                }
            );

            Line.GetComponent<LineRenderer>().widthMultiplier = 6f;
            //Line.transform.SetParent(graph.units);

            return Line;
        }

        public abstract void Generate();
    }
}
