using UnityEngine;
using System.Collections;

namespace Globals
{
    public static class Tutorials
    {
        public static bool MainTutorialHasRun = true;
        public static bool BucketTutorialHasRun = false;
        public static bool PuzzleTutorialHasRun = false;
        public static bool CameraTutorialHasRun = false;

        public static void ResetValues()
        {
            MainTutorialHasRun = false;
            BucketTutorialHasRun = false;
            PuzzleTutorialHasRun = false;
            CameraTutorialHasRun = false;
        }
    }
}