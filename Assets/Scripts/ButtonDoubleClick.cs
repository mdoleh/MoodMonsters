using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonDoubleClick : MonoBehaviour
{
    private int count = 0;
    private float timer = 0;
    private bool toggle = false;
    private Color originalColor;
    private GameObject backgroundGlow;

    protected virtual void Awake()
    {
        originalColor = GetComponent<Image>().color;
        backgroundGlow = GameObject.FindGameObjectWithTag("GUI");
    }

    public virtual void ButtonClicked()
    {
        ++count;
        if (count == 1)
        {
            GetComponent<Image>().color = Color.yellow;
            backgroundGlow.GetComponent<Image>().enabled = true;
        }
    }

    protected bool CheckCount()
    {
        return count > 1;
    }

    protected void ResetCount()
    {
        count = 0;
    }

    protected void Update()
    {
        timer += Time.deltaTime;
        if (count < 1)
        {
            if (timer > 0.5f)
            {
                ToggleBackgroundColor();
                timer = 0;
            }
        }
    }

    private void ToggleBackgroundColor()
    {
        if (toggle)
        {
            GetComponent<Image>().color = originalColor;
            backgroundGlow.GetComponent<Image>().enabled = false;
            toggle = false;
        }
        else
        {
            GetComponent<Image>().color = Color.yellow;
            backgroundGlow.GetComponent<Image>().enabled = true;
            toggle = true;
        }
    }
}
