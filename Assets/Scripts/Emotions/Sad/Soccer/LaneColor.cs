using UnityEngine;
using System.Collections;

public class LaneColor : MonoBehaviour
{
    private const float ALPHA = 0.5f;

    private void Start()
    {
        GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, ALPHA);
    }

    public void SetColor(Color newColor)
    {
        GetComponent<Renderer>().material.color = new Color(newColor.r, newColor.g, newColor.b, ALPHA);
    }
}
