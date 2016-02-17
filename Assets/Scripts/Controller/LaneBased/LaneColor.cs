using UnityEngine;


public class LaneColor : MonoBehaviour
{
    public static readonly Color CORRECT_LANE_COLOR = new Color(255, 0, 0, ALPHA);
    public static readonly Color WRONG_LANE_COLOR = new Color(255, 0, 0, ALPHA);
    private const float ALPHA = 0.5f;

    private void Start()
    {
        GetComponent<Renderer>().material.color = WRONG_LANE_COLOR;
    }

    public void SetColor(Color newColor)
    {
        GetComponent<Renderer>().material.color = new Color(newColor.r, newColor.g, newColor.b, ALPHA);
    }
}