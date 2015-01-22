using UnityEngine;
using System.Collections;

public class ButtonSceneLoadFlashing : ButtonSelect {

    public string sceneToLoad;

    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(StartAudio());
    }

    protected override void DoubleClickAction()
    {
        Utilities.LoadScene(sceneToLoad);
    }

    private IEnumerator StartAudio()
    {
        while (true)
        {
            Utilities.PlayAudio(transform.parent.GetComponent<AudioSource>());
            yield return new WaitForSeconds(5);
        }
    }
}
