using Globals;
using UnityEngine;

namespace PreSceneMenus
{
    public class SetGameFlag : MonoBehaviour
    {
        public string SceneForTesting;
        public string GameFlagToSet;

        public void AssignGameFlagNoSceneLoad(string value)
        {
            setFlag(value, false);
        }

        public void AssignGameFlagNoSceneLoad(bool value)
        {
            setFlag(value, false);
        }

        public void AssignGameFlagWithSceneLoad(string value)
        {
            setFlag(value, true);
        }

        public void AssignGameFlagWithSceneLoad(bool value)
        {
            setFlag(value, true);
        }

        private void setFlag<T>(T value, bool loadEmotionScene)
        {
            Timeout.StopTimers();
            var type = typeof(GameFlags);
            type.GetField(GameFlagToSet).SetValue(type, value);
            if (loadEmotionScene) Utilities.LoadEmotionScene(Scenes.GetNextEmotionSceneToLoad(SceneForTesting));
            else GUIHelper.NextGUI();
        }
    }
}