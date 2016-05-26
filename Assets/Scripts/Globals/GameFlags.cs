namespace Globals
{
    public static class GameFlags
    {
        public static bool GuidedTutorialHasRun = true;
        public static bool MainTutorialHasRun = true;
        public static bool BucketTutorialHasRun = true;
        public static bool PuzzleTutorialHasRun = true;
        public static bool CameraTutorialHasRun = true;
        public static bool JoyStickTutorialHasRun = true;
        public static bool HasSeenPASS = true;
        public static bool AdultIsPresent = true;
        public static string ParentGender = "Dad";
        public static string PlayerGender = "Female";

        public static void ResetValues()
        {
            GuidedTutorialHasRun = false;
            MainTutorialHasRun = false;
            JoyStickTutorialHasRun = false;
            BucketTutorialHasRun = false;
            PuzzleTutorialHasRun = false;
            CameraTutorialHasRun = false;
            HasSeenPASS = true;
            AdultIsPresent = false;
            ParentGender = "";
            PlayerGender = "";
        }
    }
}