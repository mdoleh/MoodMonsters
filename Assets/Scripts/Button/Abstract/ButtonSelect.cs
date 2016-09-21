using UnityEngine;
using System.Collections;
using Globals;
using UnityEngine.UI;

// Used for all GUI buttons that require 2 taps to execute their function
// First tap plays the description of the button's function
// Overriding DoubleClickAction() determines what the second tap does
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
        Timeout.StopTimers();
        StartCoroutine(DelayStartTimers());
    }

    private IEnumerator DelayStartTimers()
    {
        yield return new WaitForSeconds(instructions.clip.length);
        Timeout.StartTimers();
    }

    public void ClickedOff()
    {
        GetComponent<Image>().color = originalColor;
        backgroundGlow.GetComponent<Image>().enabled = false;
        ResetCount();
    }
}
