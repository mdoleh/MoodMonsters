using UnityEngine;
using UnityEngine.UI;

// Displays the device orientation for debugging purposes
public class Orientation : MonoBehaviour
{
    public Text orientationText;

    private void Update()
    {
        orientationText.text = Input.deviceOrientation.ToString();
    }
}
