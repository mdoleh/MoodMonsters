using System.Linq;
using Globals;
using UnityEngine;

namespace BlendsScene
{
    public class BlendsReset : InitOnReset
    {
        public GameObject[] parents;
        public GameObject[] children;

        protected override void Start()
        {
            GUIInitialization.Initialize();
            parents.ToList().Find(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower())).SetActive(true);
            var currentChildren = children.ToList().Find(x => x.name.ToLower().Equals(GameFlags.PlayerGender.ToLower()));
            currentChildren.SetActive(true);
            var guiList = GUIHelper.GetAllGUI();
            var emotionsIndex = guiList.ToList().FindIndex(x => x.name.ToLower().Equals("emotionscanvas4"));
            if (CanvasList.GetIndex() > emotionsIndex)
                currentChildren.GetComponentsInChildren<Animator>().ToList().ForEach(x => x.SetTrigger("Cycle"));
            base.Start();
        }
    }
}
