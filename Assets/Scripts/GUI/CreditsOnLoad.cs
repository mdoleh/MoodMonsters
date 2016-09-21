using UnityEngine;
using UnityEngine.SceneManagement;

// Moves the credits GameObject into the approprate place in the hierarchy
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
