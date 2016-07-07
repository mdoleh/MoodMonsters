using UnityEngine;

public class CanvasList : MonoBehaviour
{
    public GameObject[] Canvases;
    public GameObject[] AudioIgnoreList;
    public GameObject[] HelpCanvasIgnoreList;
    public GameObject[] DisableCanvasIgnoreList;

    private static int currentIndex = 6;

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
