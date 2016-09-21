using UnityEngine;

namespace TitleScreen
{
    // Positions the models on the Title Screen appropriately for the screen size
    public class TitleScale : MonoBehaviour
    {
        public Transform[] characters;
        public Transform soccerBall;
        public RectTransform[] titleEdges;

        private void Start()
        {
            var originalZ = characters[0].position.z;
            characters[0].position = new Vector3(titleEdges[0].position.x, titleEdges[0].position.y, originalZ);
            characters[1].position = new Vector3(titleEdges[1].position.x, titleEdges[1].position.y, originalZ);
            soccerBall.position = new Vector3(characters[0].position.x + 0.5f, soccerBall.position.y,
                soccerBall.position.z);
        }
    }
}