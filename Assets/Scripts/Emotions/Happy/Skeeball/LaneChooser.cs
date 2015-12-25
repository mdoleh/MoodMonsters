using System.Linq;
using UnityEngine;

namespace HappyScene
{
    public class LaneChooser : MonoBehaviour
    {
        public GameObject[] lanes;
        public GameObject[] goalHighlighters;
        public static GameObject correctLane;

        public void ChooseLane()
        {
            var index = Random.Range(0, lanes.Length);
            correctLane = lanes[index];
            HideAllHighlighers();
            goalHighlighters[index].GetComponent<MeshRenderer>().enabled = true;
        }

        public void HideAllHighlighers()
        {
            goalHighlighters.ToList().ForEach(x =>
            {
                x.GetComponent<MeshRenderer>().enabled = false;
                var color = x.GetComponent<Renderer>().material.color;
                x.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0.5f);
            });
        }
    }
}