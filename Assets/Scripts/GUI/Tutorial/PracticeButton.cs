using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PracticeButton : ButtonDragDrop {
    protected override void Awake()
    {
        base.Awake();
        CORRECT_AMOUNT = 1;
    }

    public override void ButtonDown()
    {
        base.ButtonDown();
        ShowDragging();
    }

    public override void ButtonRelease()
    {
        base.ButtonRelease();
        ShowPushing();
    }

    private void ShowDragging()
    {
        transform.parent.Find("ButtonPush").GetComponent<RawImage>().enabled = false;
        transform.parent.Find("ButtonPush").GetComponent<Animator>().enabled = false;
        transform.parent.Find("ButtonDrag").GetComponent<RawImage>().enabled = true;
        transform.parent.Find("ButtonDrag").GetComponent<Animator>().enabled = true;
    }

    private void ShowPushing()
    {
        transform.parent.Find("ButtonPush").GetComponent<RawImage>().enabled = true;
        transform.parent.Find("ButtonPush").GetComponent<Animator>().enabled = true;
        transform.parent.Find("ButtonDrag").GetComponent<RawImage>().enabled = false;
        transform.parent.Find("ButtonDrag").GetComponent<Animator>().enabled = false;
    }
}
