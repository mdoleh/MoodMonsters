using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Globals
{
    // Constantly running the background, tracks how long the player has left the game idle
    // When hitting the threshold, the game will reset itself to the Title Screen
    public class Timeout : MonoBehaviour
    {
        public float TimeUntilReset;
        public float TimeUntilRepeat;

        public static Timeout Instance;
        public static AudioSource WarningAudio;

        private static AudioSource RepeatAudio;
        private float repeatTimer = 0f;
        private float resetTimer = 0f;
        private bool shouldRunTimers = false;
        private bool shouldReset = false;

        private void Awake()
        {
            WarningAudio = transform.FindChild("WarningAudio").GetComponent<AudioSource>();
            Instance = gameObject.GetComponent<Timeout>();
            enabled = false;
        }

        private void Update()
        {
            if (!shouldRunTimers) return;
            repeatTimer += Time.deltaTime;
            if (resetTimer >= TimeUntilReset && !shouldReset)
            {
                Utilities.PlayAudio(WarningAudio);
                shouldReset = true;
                resetTimer = 0f;
            }
            else if (repeatTimer >= TimeUntilRepeat)
            {
                if (shouldReset) SceneManager.LoadScene("TitleScreen");
                resetTimer += repeatTimer;
                repeatTimer = 0f;
                StartCoroutine(PlayAudio());
            }
        }

        private IEnumerator PlayAudio()
        {
            shouldRunTimers = false;
            Utilities.PlayAudio(RepeatAudio);
            if (RepeatAudio != null) 
                yield return new WaitForSeconds(RepeatAudio.clip.length);
            StartTimers();
        }

        // Restarts the timer, typically done when the player
        // can interact with the screen
        public static void StartTimers()
        {
            Instance.shouldRunTimers = true;
            Instance.enabled = true;
        }

        // Stops the timer, typically done when the player
        // is not able to interact with the screen
        public static void StopTimers()
        {
            Instance.shouldRunTimers = false;
            Instance.shouldReset = false;
            Instance.repeatTimer = 0f;
            Instance.resetTimer = 0f;
            Instance.enabled = false;
        }

        public static void ResetValues()
        {
            StopTimers();
            Instance.TimeUntilRepeat = 15f;
            Instance.TimeUntilReset = 60f;
        }

        public static void SetRepeatAudio(AudioSource audioToRepeat)
        {
            RepeatAudio = audioToRepeat;
        }

        public static AudioSource GetRepeatAudio()
        {
            return RepeatAudio;
        }
    }
}