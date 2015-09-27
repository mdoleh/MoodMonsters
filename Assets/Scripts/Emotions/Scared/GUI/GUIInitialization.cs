﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Globals;

namespace ScaredScene
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
                "ParentPayAttentionAskCanvas" + GameFlags.ParentGender,
                "ParentSupportCanvas" + GameFlags.ParentGender,
                "ParentSolveCanvas" + GameFlags.ParentGender,
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
                "SituationActionsCanvas"
            };
            GUIHelper.AudioIgnoreList = new List<string> { "ControllerCanvas" };
        }
    }
}