using System.Collections.Generic;
using System.Linq;

namespace Globals
{
    public static class Scenes
    {
        public static string NextSceneToLoad;
        public static string SceneForTesting = "AngrySceneSmallCity";

        public static IList<string> CompletedScenes = new List<string>();

        public static IList<string> MiniGames = new List<string>
        {
            "EggDropMiniGame", "PuzzleMiniGame"
        };

        public static string GetNextMiniGame()
        {
            var puzzleToLoad = MiniGames[0];
            MiniGames.Remove(puzzleToLoad);
            return puzzleToLoad;
        }

        public static void ResetValues()
        {
            CompletedScenes = new List<string>();
        }

        public static string GetLastSceneCompleted()
        {
            return CompletedScenes.Count == 0 ? SceneForTesting : CompletedScenes.Last();
        }
    }
}

