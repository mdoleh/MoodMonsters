using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsOnLoad : MonoBehaviour
{
    public Transform LastItem;

    private void Start()
    {
        var placeholder = GameObject.FindGameObjectWithTag("ScrollPlaceholder");
        transform.parent = placeholder.transform.parent;
        transform.localPosition = placeholder.transform.localPosition;
        Destroy(placeholder);
        transform.GetComponentInParent<Scroll>().lastItem = LastItem;
        SceneManager.UnloadScene("Credits");
    }
}
