using Globals;

namespace PreSceneMenus
{
    public class BoyOrGirl : DelayShowCanvas
    {
        public void Boy()
        {
            GameFlags.PlayerGender = "Male";
            handleClick();
        }

        public void Girl()
        {
            GameFlags.PlayerGender = "Female";
            handleClick();
        }

        private void handleClick()
        {
            Timeout.StopTimers();
            Utilities.LoadEmotionScene(Scenes.GetNextEmotionSceneToLoad("EmotionBlendsSceneSmallCity"));
        }
    }
}