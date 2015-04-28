using UnityEngine;
using System.Collections;

namespace Globals
{
    public static class Tutorials
    {
        public static bool MainTutorialHasRun = true;
        public static bool PuzzleTutorialHasRun = false;

        public static void ResetValues()
        {
            MainTutorialHasRun = false;
            PuzzleTutorialHasRun = false;
        }
    }
}