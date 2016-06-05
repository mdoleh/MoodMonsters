using System.Linq;
using Globals;
using UnityEngine;

namespace BlendsScene
{
    public class TalkAboutIt : CorrectActionBase
    {
        public DialogueParent[] parents;

        protected override void DialogueAnimation()
        {
            anim.SetTrigger("Ask");
        }

        protected override void AfterDialogue()
        {
            anim.SetTrigger("Idle");
            var parent =
                parents.ToList().Find(x => x.gameObject.name.ToLower().Contains(GameFlags.ParentGender.ToLower()));
            parent.ExplainNewJob();
        }
    }
}