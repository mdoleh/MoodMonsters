using UnityEngine;
using System.Collections;

public class StartButton : ButtonDoubleClick
{
    public string sceneToLoad;
    private AudioSource instructions;

    protected override void Awake()
    {
        base.Awake();
        instructions = GetComponent<AudioSource>();
    }

    public override void ButtonClicked()
    {
        base.ButtonClicked();
        if (CheckCount())
        {
            ResetCount();
            Utilities.LoadScene(sceneToLoad);
        }
        else
        {
            Utilities.PlayAudio(instructions);
        }
    }
}
