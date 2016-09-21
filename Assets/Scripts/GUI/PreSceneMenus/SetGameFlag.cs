using Globals;
using UnityEngine;

namespace PreSceneMenus
{
    // Used by pre-scene questions to set GameFlags
    public class SetGameFlag : MonoBehaviour
    {
        public string SceneForTesting;
        public string GameFlagToSet;

        public void AssignGameFlag(string value, bool loadScene)
        {
            bool result;
            if (bool.TryParse(value, out result))
                setFlag(result, loadScene);
            else
                setFlag(value, loadScene);
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