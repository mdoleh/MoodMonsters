using UnityEngine;
using System.Collections;
using HappyScene;

public class VendorAnimations : MonoBehaviour
{
    public SkeeballCharacterMovement playerCharacter;
    public Transform largePrize;
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
        anim.SetTrigger("TurnAround");
    }

    public void GetPrizeEvent()
    {
        anim.SetTrigger("PickupPrize");
    }

    public void AdjustPrizePositionEvent()
    {
        largePrize.position = rightHand.position;
        largePrize.parent = rightHand;
    }

    public void TurnAroundEvent()
    {
        anim.SetTrigger("TurnAround");
    }

    public void PutDownPrizeEvent()
    {
        anim.SetTrigger("PutDownPrize");
    }

    public void PutPrizeOnGroundEvent()
    {
        largePrize.parent = null;
        largePrize.position = new Vector3(216.997f, 5.114f, 165.192f);
        largePrize.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
    }

    public void TakePrizeEvent()
    {
        anim.SetTrigger("Idle");
        playerCharacter.TakePrize();
    }
}
