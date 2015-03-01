using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Globals;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    
    public int theScore = 0;
    public GameObject[] instructions;
    public GameObject[] stars;
    private string lastSceneCompleted;
    public static bool shouldDropEggs = false;
    private float lastInput;

    private void Awake()
    {
        Timeout.StopTimers();
        lastSceneCompleted = Scenes.GetLastSceneCompleted();
        StartCoroutine(DelayedPlayAudio());
    }

    private IEnumerator DelayedPlayAudio()
    {
        yield return new WaitForSeconds(1.0f);
        var instructions = GetAudioInstructions();
        Utilities.PlayAudio(instructions);
        yield return new WaitForSeconds(instructions.clip.length);

        var avoidInstructions = GetAudioInstructions("avoid");
        Utilities.PlayAudio(avoidInstructions);
        yield return new WaitForSeconds(avoidInstructions.clip.length);

        var controlInstructions = GetControlInstructions();
        ShowDraggingAnimation();
        Utilities.PlayAudio(controlInstructions);
        yield return new WaitForSeconds(controlInstructions.clip.length);
        HideDraggingAnimation();

        shouldDropEggs = true;
    }

    private void ShowDraggingAnimation()
    {
        GameObject.Find("TutorialCanvas").GetComponent<Canvas>().enabled = true;
    }

    private void HideDraggingAnimation()
    {
        GameObject.Find("TutorialCanvas").GetComponent<Canvas>().enabled = false;
    }

    private AudioSource GetAudioInstructions()
    {
        return (from instruction in instructions where lastSceneCompleted.Contains(instruction.name) select instruction.GetComponent<AudioSource>()).FirstOrDefault();
    }

    private AudioSource GetAudioInstructions(string name)
    {
        return (from instruction in instructions where instruction.name.ToLower().Equals(name) select instruction.GetComponent<AudioSource>()).FirstOrDefault();
    }

    private AudioSource GetControlInstructions()
    {
        return GameObject.Find("ButtonDrag").GetComponent<AudioSource>();
    }

    private void Start()
    {
        Timeout.StartTimers();
    }

	void Update () {
        //These two lines are all there is to the actual movement..
        float moveInput = Input.GetAxis("Horizontal") * Time.deltaTime * 0.25f; 
        if (moveInput == lastInput) Timeout.StartTimers();
        else Timeout.StopTimers();
        transform.position += new Vector3(moveInput, 0, 0);

        //Restrict movement between two values
        if (transform.position.x <= -2.5f || transform.position.x >= 2.5f)
        {
            float xPos = Mathf.Clamp(transform.position.x, -2.5f, 2.5f); //Clamp between min -2.5 and max 2.5
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
	    lastInput = moveInput;
	}

    public void UpdateScore(int value)
    {
        theScore += value;
        HideAllStars();
        ShowStars();
    }

    private void HideAllStars()
    {
        foreach (var star in stars)
        {
            star.SetActive(false);
        }
    }

    private void ShowStars()
    {
        for (var i = 0; i < theScore; ++i)
        {
            stars[i].SetActive(true);
        }
    }
}