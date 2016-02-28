using UnityEngine;
using System.Collections;

namespace HappyScene
{
    public class VendorAnimations : MonoBehaviour
    {
        public PlayerPickupPrize playerCharacter;
        public Transform prizeBear;
        public Transform rightHand;
        public AudioSource wonPrizeAudio;

        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void WonPrize()
        {
            StartCoroutine(wonPrize());
        }

        private IEnumerator wonPrize()
        {
            yield return new WaitForSeconds(1.5f);
            anim.SetTrigger("Talk");
            Utilities.PlayAudio(wonPrizeAudio);
            yield return new WaitForSeconds(wonPrizeAudio.clip.length);
            playerCharacter.Turn();
            anim.SetTrigger("TurnAround");
        }

        public void GetPrizeEvent()
        {
            anim.SetTrigger("PickupPrize");
        }

        public void AdjustPrizePositionEvent()
        {
            prizeBear.position = rightHand.position;
            prizeBear.parent = rightHand;
        }

        public void TurnAroundEvent()
        {
            anim.SetTrigger("TurnAround");
        }

        public void PutDownPrizeEvent()
        {
            anim.SetTrigger("PutDownPrize");
        }

        public void TakePrize()
        {
            playerCharacter.TakePrize();
        }

        public void Idle()
        {
            anim.SetTrigger("Idle");
        }

        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerPickupPrize>();
            if (player != null)
            {
                player.StopWalking();
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }
}