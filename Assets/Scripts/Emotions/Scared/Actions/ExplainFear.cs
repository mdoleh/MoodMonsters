using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

namespace ScaredScene
{
    public class ExplainFear : ActionBase
    {
        public Animator otherAnim;
        public GameObject[] parentCharacters;
        public AudioSource scaredDialogue;
        public AudioSource afraidToFallDialogue;

        private GameObject currentParent;

        private void Start()
        {
            currentParent = parentCharacters.ToList().First(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower()));
        }

        private void VoiceFear()
        {
            anim.SetTrigger("Talking");
            Utilities.PlayAudio(scaredDialogue);
        }

        public void GetEncouragement()
        {
            anim.SetTrigger("Idle");
            if (GameFlags.AdultIsPresent)
            {
                sceneReset.sceneToLoadIncorrect = "ScaredSceneSmallCityParentActionsMenu";
                GUIHelper.GetPreviousGUI("ParentActionsCanvas" + GameFlags.ParentGender).enabled = true;
                GUIHelper.NextGUI();
            }
            else
            {
                otherAnim.GetComponent<Conversation>().GiveEncouragement();
            }
        }

        public void StartJumpSequence()
        {
            gameObject.GetComponent<FearfulMovement>().WalkBackwards();
        }

        public void AfraidToFall()
        {
            anim.SetTrigger("ScaredToFall");
            Utilities.PlayAudio(afraidToFallDialogue);
        }

        public void GetComfort()
        {
            anim.SetTrigger("Idle");
            if (GameFlags.AdultIsPresent)
            {
                currentParent.GetComponent<Comfort>().GiveComfort();
            }
            else
            {
                otherAnim.GetComponent<Conversation>().GiveComfort();
            }
        }

        public override void StartAction()
        {
            base.StartAction();
            ShowCorrect(true);
            StartCoroutine(Explain());
        }

        private IEnumerator Explain()
        {
            Utilities.PlayAudio(actionExplanation);
            yield return new WaitForSeconds(actionExplanation.clip.length);
            ShowCorrect(false);
            VoiceFear();
        }

        public void GoToMiniGame()
        {
            sceneReset.TriggerCorrect(null, Scenes.GetNextMiniGame(), false);
        }
    }
}