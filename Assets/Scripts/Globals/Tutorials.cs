using UnityEngine;
using System.Collections;

namespace Globals
{
    public static class Tutorials
    {
        public static bool MainTutorialHasRun = true;
        public static bool BucketTutorialHasRun = true;
        public static bool PuzzleTutorialHasRun = true;
        public static bool CameraTutorialHasRun = true;

        public static void ResetValues()
        {
            MainTutorialHasRun = false;
            BucketTutorialHasRun = false;
            PuzzleTutorialHasRun = false;
            CameraTutorialHasRun = false;
        }
    }
}