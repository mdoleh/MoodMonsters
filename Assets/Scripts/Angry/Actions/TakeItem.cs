using UnityEngine;
using System.Collections;
using Globals;

namespace AngryScene
{
    public class TakeItem : MonoBehaviour
    {
        private GameObject dialogue;
        private GameObject ipadCamera;
        private GameObject miniGame;
        protected Animator anim;
        public Animator other;

        public void Awake()
        {
            dialogue = transform.FindChild("Dialogue").gameObject;
            ipadCamera = GameObject.Find("iPadCamera");
            miniGame = GameObject.Find("MiniGame");
            anim = GetComponent<Animator>();
        }

        public IEnumerator StartTalking()
        {
            yield return new WaitForSeconds(1f);
            anim.SetTrigger("IsTalking");
            var letMePlay = dialogue.transform.FindChild("LetMePlay").GetComponent<AudioSource>();
            Utilities.PlayAudio(letMePlay);
            yield return new WaitForSeconds(letMePlay.clip.length + 2f);
            var comeOn = dialogue.transform.FindChild("ComeOn").GetComponent<AudioSource>();
            Utilities.PlayAudio(comeOn);
        }

        public void TakeIPad()
        {
            ipadCamera.SetActive(false);
            miniGame.SetActive(false);

            anim.SetTrigger("IsTakingIPad");
            other.SetBool("IsUsingIPad", false);
            other.SetTrigger("IsLosingIPad");
            StartCoroutine(DelayGUI());
        }

        private IEnumerator DelayGUI()
        {
            yield return new WaitForSeconds(1f);
            StartGUI();
        }

        public void StartUsingIPad() {
            anim.SetBool("IsUsingIPad", true);
            other.SetTrigger("IsAngry");
        }

        public virtual void MoveIpad()
        {
            var ipad = GameObject.Find("iPad");
            var hand = GameObject.Find("Boy:RightHand");
            ipad.transform.parent = hand.transform;
            ipad.transform.localPosition = new Vector3(0.16965f, -0.18118f, 0.20516f);
            ipad.transform.localRotation = Quaternion.Euler(0.5527962f, 278.4825f, 301.6339f);
        }

        public virtual void ShiftToLeftHand()
        {
            var ipad = GameObject.Find("iPad");
            var hand = GameObject.Find("Boy:LeftHand");
            ipad.transform.parent = hand.transform;
            ipad.transform.localPosition = new Vector3(-0.15317f, -0.17448f, 0.1441f);
            ipad.transform.localRotation = Quaternion.Euler(334.0472f, 53.15136f, 93.76542f);
        }

        void StartGUI()
        {
            Timeout.StartTimers();
            GUIDetect.NextGUI();
            enabled = false;
        }
    }
}