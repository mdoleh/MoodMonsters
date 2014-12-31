using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonDoubleClick : MonoBehaviour
{
    public string sceneToLoad;

    private AudioSource instructions;
    private int count = 0;
    private float timer = 0;
    private bool toggle = false;
    protected Color originalColor;
    private Transform backgroundGlow;

    protected virtual void Awake()
    {
        originalColor = GetComponent<Image>().color;
        backgroundGlow = transform.parent.Find("BackgroundGlow");
        instructions = GetComponent<AudioSource>();
    }

    public virtual void ButtonClicked()
    {
        ++count;
        if (count == 1)
        {
            GetComponent<Image>().color = Color.yellow;
            backgroundGlow.GetComponent<Image>().enabled = true;
        }
        if (count > 1)
        {
            count = 0;
            Utilities.LoadScene(sceneToLoad);
        }
        else
        {
            Utilities.PlayAudio(instructions);
        }
    }

    protected virtual void Update()
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
