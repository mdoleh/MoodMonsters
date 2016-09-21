using UnityEngine;

public class CanvasList : MonoBehaviour
{
    // master list of all canvases
    public GameObject[] Canvases;
    // list of canvases where audio should not be played
    // (ex: ControllerCanvas, Parent Default Canvases in the Sad Scene)
    public GameObject[] AudioIgnoreList;
    // list of canvases where the HelpCanvas should remain disabled
    // (ex: Parent Default Canvases in the Sad Scene)
    public GameObject[] HelpCanvasIgnoreList;
    // list of canvases where they should not be
    // disabled when navigating to the next canvas
    // (ex: ControllerCanvas in the Scared Scene)
    public GameObject[] DisableCanvasIgnoreList;

    private static int currentIndex = 0;

    public static void IncrementIndex()
    {
        ++currentIndex;
    }

    public static int GetIndex()
    {
        return currentIndex;
    }

    public static void ResetIndex()
    {
        currentIndex = 0;
    }

    // for debugging use only
    public static void SetIndex(int index)
    {
        currentIndex = index;
    }
}
