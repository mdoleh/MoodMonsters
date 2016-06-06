using PreSceneMenus;

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
