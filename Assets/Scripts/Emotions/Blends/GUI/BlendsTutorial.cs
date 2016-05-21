using System.Collections;
using System.Linq;
using Globals;
using UnityEngine;

namespace BlendsScene
{
    public class BlendsTutorial : TutorialBase
    {
        public GameObject[] childrenPairs;
        public GameObject[] parents;
        public AudioSource[] introAudioClips;
        public AudioSource[] hereComesParent;

        private GameObject currentParent;

        public override void InitializeGameObjects()
        {
            helpCanvas = GameObject.Find("HelpCanvas");
            disablePanel = helpCanvas.transform.FindChild("DisablePanel").gameObject;
            noInputSymbol = disablePanel.transform.FindChild("NoInputSymbol").gameObject;

            GameFlags.ParentGender = Random.Range(0, 2) == 0 ? "Mom" : "Dad";
            childrenPairs.ToList().Find(x => x.name.ToLower().Contains(GameFlags.PlayerGender.ToLower())).SetActive(true);
            currentParent = parents.ToList().Find(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower()));
        }

        protected override void InitializeAudio()
        {
            introAudio = introAudioClips.ToList()
                .Find(x => x.gameObject.name.ToLower().Contains(GameFlags.PlayerGender.ToLower()));
        }

        protected override void HelpExplanationComplete()
        {
            base.HelpExplanationComplete();
            StartCoroutine(playHereComesParent());
        }

        private IEnumerator playHereComesParent()
        {
            var audioToPlay =
                hereComesParent.ToList().Find(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower()));
            Utilities.PlayAudio(audioToPlay);
            yield return new WaitForSeconds(audioToPlay.clip.length);
            currentParent.SetActive(true);
        }
    }
}