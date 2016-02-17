using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HappyScene
{
    public class GoalChooser : MonoBehaviour
    {
        public GameObject[] goalHighlighters;
        public static GameObject correctGoal;

        private bool shouldFlashHighlighers = true;

        public void ChooseLane()
        {
            var index = Random.Range(0, goalHighlighters.Length);
            correctGoal = goalHighlighters[index];
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

        public IEnumerator FlashBonusHighlighters()
        {
            yield return new WaitForSeconds(0.5f);
            if (!shouldFlashHighlighers) yield break;
            goalHighlighters.ToList().ForEach(x => x.GetComponent<MeshRenderer>().enabled = !x.GetComponent<MeshRenderer>().enabled);
            StartCoroutine(FlashBonusHighlighters());
        }

        public void StopFlashingHighlighters()
        {
            shouldFlashHighlighers = false;
            HideAllHighlighers();
        }
    }
}