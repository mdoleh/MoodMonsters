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
            resetAllHighlighers();
            goalHighlighters[index].SetActive(true);
        }

        private void resetAllHighlighers()
        {
            goalHighlighters.ToList().ForEach(x =>
            {
                x.SetActive(false);
                var color = x.GetComponent<Renderer>().material.color;
                x.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0.5f);
            });
        }
    }
}