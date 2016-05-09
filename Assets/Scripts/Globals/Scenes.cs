using System.Collections.Generic;
using System.Linq;

namespace Globals
{
    public static class Scenes
    {
        public static bool LoadingSceneThroughDebugging = false;
        public static int CurrentMiniGameIndex = 0;
        public static string NextSceneToLoad;
        public static string LastLoadedScene;
        private const string SceneForTestingParentPresent = "SadSceneSmallCity";
        private const string EmotionForTestingMinigames = "AngrySceneSmallCity";
        private const string LastLoadedSceneForTesting = "TitleScreen";

        public static IList<string> CompletedScenes = new List<string>();

        public static IList<string> MiniGames = new List<string>
        {
            "EggDropMiniGame", "PuzzleMiniGame"
        };

        public static string GetNextMiniGame()
        {
            if (MiniGames.Count <= CurrentMiniGameIndex) return string.Empty;
            var gameToLoad = MiniGames[CurrentMiniGameIndex++];
            if (CurrentMiniGameIndex == MiniGames.Count) CurrentMiniGameIndex = 0;
            return gameToLoad;
        }

        public static void ResetValues()
        {
            CompletedScenes = new List<string>();
            NextSceneToLoad = "";
        }

        public static string GetLastEmotionCompleted()
        {
            return HasCompletedScenes() ? EmotionForTestingMinigames : CompletedScenes.Last();
        }

        public static string GetNextSceneToLoadForParentPresent()
        {
            return string.IsNullOrEmpty(NextSceneToLoad) ? SceneForTestingParentPresent : NextSceneToLoad;
        }

        public static string GetLastLoadedScene()
        {
            return string.IsNullOrEmpty(LastLoadedScene) ? LastLoadedSceneForTesting : LastLoadedScene;
        }

        public static bool HasCompletedScenes()
        {
            return CompletedScenes.Count == 0;
        }

        public static bool HasCompletedAllScenes()
        {
            return CompletedScenes.Count >= 4;
        }
    }
}

