﻿using UnityEngine;
using System.Collections;

namespace Globals
{
    public class Tutorials : MonoBehaviour
    {
        public static bool MainTutorialHasRun = false;
        public static bool PuzzleTutorialHasRun = false;

        public static void ResetValues()
        {
            MainTutorialHasRun = false;
            PuzzleTutorialHasRun = false;
        }
    }
}