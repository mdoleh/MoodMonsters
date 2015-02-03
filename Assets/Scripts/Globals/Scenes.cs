using System.Collections.Generic;

namespace Globals
{
    public static class Scenes
    {
        public static string NextSceneToLoad;

        public static IList<string> CompletedScenes = new List<string>();

        public static IList<string> Puzzles = new List<string>
        {
            "PuzzleTutorial", "PuzzleLevel1", "PuzzleLevel2"
        };

        public static string GetNextPuzzle()
        {
            var puzzleToLoad = Puzzles[0];
            Puzzles.Remove(puzzleToLoad);
            return puzzleToLoad;
        }

        public static void ResetValues()
        {
            CompletedScenes = new List<string>();
        }
    }
}

