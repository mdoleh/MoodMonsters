using System.Collections.Generic;

namespace Globals
{
    public static class Scenes
    {
        public static string NextSceneToLoad;

        public static IList<string> CompletedScenes = new List<string>();

        public static IList<string> MiniGames = new List<string>
        {
            "EggDrop", "PuzzleMiniGame"
        };

        public static string GetNextGame()
        {
            var puzzleToLoad = MiniGames[0];
            MiniGames.Remove(puzzleToLoad);
            return puzzleToLoad;
        }

        public static void ResetValues()
        {
            CompletedScenes = new List<string>();
        }
    }
}

