using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class ButtonSelect : ButtonDoubleClick
{
    protected AudioSource instructions;

    protected override void Awake()
    {
        base.Awake();
        instructions = GetComponent<AudioSource>();
    }

    protected override void SingleClickAction()
    {
        Utilities.PlayAudio(instructions);
    }

    public void ClickedOff()
    {
        GetComponent<Image>().color = originalColor;
        backgroundGlow.GetComponent<Image>().enabled = false;
        ResetCount();
    }
}
