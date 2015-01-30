using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Globals
{
    public class Scenes : MonoBehaviour 
    {
        public enum SceneState
        {
            Tutorial = 0,
            Emotions = 1,
            Physical = 2,
            Actions = 3,
            Puzzle = 4
        }

        public static SceneState CurrentState;

        public static IList<string> CompletedScenes = new List<string>();

        public static void ResetValues()
        {
            CompletedScenes = new List<string>();
        }
    }
}

