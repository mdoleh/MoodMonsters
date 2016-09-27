using UnityEngine;

namespace HappyScene
{
    // Keeps track of the player's skeeball score
    public class SkeeballScore : MonoBehaviour
    {
        public int Score = 0;

        public void IncreaseScore(int amount)
        {
            Score += amount;
            updateScoreText();
        }

        private void updateScoreText()
        {
            GetComponent<TextMesh>().text = Score.ToString();
        }
    }
}