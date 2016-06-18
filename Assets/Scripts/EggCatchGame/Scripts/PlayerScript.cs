using Globals;
using UnityEngine;

namespace EggCatch
{
    public class PlayerScript : MonoBehaviour
    {

        public int theScore = 0;
        public GameObject[] stars;
        public bool shouldDropEggs = false;
        public int MAX_SCORE = 5;

        private float lastInput;

        protected void Start()
        {
            Timeout.StartTimers();
        }

        protected virtual void Update()
        {
            float moveInput = (Input.mousePosition.x / Screen.width) * 5f;
            if (moveInput == lastInput) Timeout.StartTimers();
            else Timeout.StopTimers();
            
            transform.position = new Vector3(Mathf.Clamp(moveInput - 2.5f, -2.5f, 2.5f), transform.position.y, transform.position.z);

            lastInput = moveInput;
        }

        public virtual void UpdateScore(int value)
        {
            if (theScore < MAX_SCORE) theScore += value;
            else shouldDropEggs = false;
            HideAllStars();
            ShowStars();
        }

        private void HideAllStars()
        {
            foreach (var star in stars)
            {
                star.SetActive(false);
            }
        }

        private void ShowStars()
        {
            for (var i = 0; i < theScore; ++i)
            {
                stars[i].SetActive(true);
            }
        }
    }
}