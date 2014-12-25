using UnityEngine;
using System.Collections;

public class StartMenuButton : MonoBehaviour
{
    public string sceneToLoad;

    protected void ButtonClick()
    {
        Utilities.LoadScene(sceneToLoad);
    }
}
