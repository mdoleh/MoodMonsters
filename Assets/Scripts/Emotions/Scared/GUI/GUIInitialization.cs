using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ScaredScene
{
    public class GUIInitialization : MonoBehaviour
    {
        public static void Initialize()
        {
            GUIHelper.CanvasList = new List<string>
            {
                "TutorialCanvas", 
                "ControllerCanvas", 
                "EmotionsCanvas", 
                "PhysicalCanvas1", 
                "PhysicalCanvas2", 
                "PhysicalCanvas3", 
                "ActionsCanvas"
            };
            GUIHelper.AudioIgnoreList = new List<string> { "ControllerCanvas" };
        }
    }
}