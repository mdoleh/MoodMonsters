using System.Collections;
using Globals;
using ScaredScene;
using UnityEngine;

public class EdgeSlipTrigger : MonoBehaviour
{
    public bool AlwaysStumble = false;
    private bool shouldJump = false;

    void OnTriggerEnter(Collider other)
    {
        if (AlwaysStumble || (!shouldJump && other.gameObject.GetComponent<FearfulMovement>() != null))
        {
            other.gameObject.GetComponent<CharacterMovement>().EdgeSlip();
            shouldJump = true;
            if (AlwaysStumble)
            {
                StartCoroutine(JumpDownSequence(other));
            }
        }
        else
        {
            other.gameObject.GetComponent<CharacterMovement>().RunJump();
        }
    }

    private IEnumerator JumpDownSequence(Collider other)
    {
        Timeout.StopTimers();
        var audioSource = GetComponent<AudioSource>();
        Utilities.PlayAudio(audioSource);
        yield return new WaitForSeconds(audioSource.clip.length);
        other.gameObject.GetComponent<CharacterMovement>().TurnRight();
    }
}
