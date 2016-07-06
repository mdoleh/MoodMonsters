using UnityEngine;
using System.Collections;
using Globals;
using UnityEngine.UI;

namespace AngryScene
{
    public class TakeItem : MonoBehaviour
    {
        public Animator other;
        public GameObject ipadCamera;
        public GameObject ipad;
        public Transform leftHand;
        public Transform rightHand;
        protected Animator anim;
        private GameObject dialogue;
        private GameObject miniGame;
        private GameObject ipadCanvas;

        public void Awake()
        {
            dialogue = transform.FindChild("Dialogue").gameObject;
            ipadCanvas = GameObject.Find("iPadCanvas");
            miniGame = GameObject.Find("MiniGame");
            anim = GetComponent<Animator>();
        }

        public IEnumerator StartTalking()
        {
            yield return new WaitForSeconds(1f);
            hideIpadGame();
            anim.SetTrigger("IsTalking");
            var letMePlay = dialogue.transform.FindChild("LetMePlay").GetComponent<AudioSource>();
            Utilities.PlayAudio(letMePlay);
            yield return new WaitForSeconds(letMePlay.clip.length);
        }

        private void hideIpadGame()
        {
            ipadCamera.SetActive(false);
            ipadCanvas.SetActive(false);
            miniGame.SetActive(false);
        }

        public void TriggerFootStamp()
        {
            anim.SetTrigger("IsTalking");
            StartCoroutine(PlayComeOnDialogue());
        }

        private IEnumerator PlayComeOnDialogue()
        {
            yield return new WaitForSeconds(1.5f);
            var comeOn = dialogue.transform.FindChild("ComeOn").GetComponent<AudioSource>();
            Utilities.PlayAudio(comeOn);
        }

        public void TakeIPad()
        {
            anim.SetTrigger("IsTakingIPad");
            other.SetFloat("Speed", 1.0f);
            other.SetBool("IsUsingIPad", false);
            other.SetTrigger("IsLosingIPad");
            StartCoroutine(disableSelf());
        }

        private IEnumerator disableSelf()
        {
            yield return new WaitForSeconds(1f);
            enabled = false;
        }

        public void StartUsingIPad() {
            anim.SetBool("IsUsingIPad", true);
            other.SetTrigger("IsAngry");
        }

        public virtual void MoveIpad()
        {
            ipad.transform.parent = rightHand;
            ipad.transform.localPosition = new Vector3(-0.133f, 0.094f, 0.085f);
            ipad.transform.localRotation = Quaternion.Euler(90f, 235.7971f, 0f);
        }

        public virtual void ShiftToLeftHand()
        {
            ipad.transform.parent = leftHand;
            ipad.transform.localPosition = new Vector3(0.093f, 0.137f, 0.136f);
            ipad.transform.localRotation = Quaternion.Euler(66.94399f, 118.2474f, 34.07929f);
        }
    }
}