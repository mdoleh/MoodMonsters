using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Globals;

namespace SadScene
{
    public class GUIInitialization : MonoBehaviour
    {
        public static void Initialize()
        {
            GUIHelper.CanvasList = GameFlags.AdultIsPresent
            ? new List<string>
            {
                "TutorialCanvas",
                "ControllerCanvas",
                "EmotionsCanvas",
                "PhysicalCanvas1",
                "PhysicalCanvas2",
                "PhysicalCanvas3",
                "EmotionActionsCanvas",
                "ParentActionsCanvas" + GameFlags.ParentGender,
                "SituationActionsCanvas"
            }
            : new List<string>
            {
                "TutorialCanvas",
                "ControllerCanvas",
                "EmotionsCanvas",
                "PhysicalCanvas1",
                "PhysicalCanvas2",
                "PhysicalCanvas3",
                "EmotionActionsCanvas",
                "ParentDefaultCanvas", 
                "SituationActionsCanvas"
            };
            GUIHelper.AudioIgnoreList = new List<string> { "ControllerCanvas" };
            GUIHelper.HelpCanvasIgnoreList = new List<string> { "ParentDefaultCanvas" };
        }
    }
}