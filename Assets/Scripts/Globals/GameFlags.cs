using UnityEngine;
using System.Collections;

namespace Globals
{
    public static class GameFlags
    {
        public static bool MainTutorialHasRun = true;
        public static bool BucketTutorialHasRun = true;
        public static bool PuzzleTutorialHasRun = true;
        public static bool CameraTutorialHasRun = true;
        public static bool JoyStickTutorialHasRun = true;
        public static bool AdultIsPresent = true;
        public static string ParentGender = "mom";

        public static void ResetValues()
        {
            MainTutorialHasRun = false;
            BucketTutorialHasRun = false;
            PuzzleTutorialHasRun = false;
            CameraTutorialHasRun = false;
            AdultIsPresent = false;
            ParentGender = "";
        }
    }
}