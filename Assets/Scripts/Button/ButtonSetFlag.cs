using PreSceneMenus;

// Used by GUI buttons to set game flags
// (ex: Pre-Scene questions about Adult Present or Player Gender)
public class ButtonSetFlag : ButtonSelect
{
    public SetGameFlag flagSetter;
    public string flagValue;
    public bool loadScene;

    protected override void DoubleClickAction()
    {
        flagSetter.AssignGameFlag(flagValue, loadScene);
    }

    protected override void Update()
    {
        // disable flashing
    }
}
