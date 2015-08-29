using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Globals;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    
    public int theScore = 0;
    public GameObject[] stars;
    public bool shouldDropEggs = false;
    public bool shouldKeepScore = true;
    public Animator Lily;
    private float lastInput;
    private float animationDelay = 0.0f;

    private void Start()
    {
        Timeout.StartTimers();
    }

	void Update () {
        //These two lines are all there is to the actual movement..
        float moveInput = Input.GetAxis("Mouse X") * Time.deltaTime * 0.1f;
	    if (shouldKeepScore)
	    {
	        if (moveInput == lastInput) Timeout.StartTimers();
            else Timeout.StopTimers();
	    }
	    else
	    {
	        animationDelay += Time.deltaTime;
	        if (animationDelay >= 1)
	        {
	            Lily.SetTrigger(moveInput > 0 ? "SwipeRight" : "SwipeLeft");
	            animationDelay = 0.0f;
	        }
	    }
        
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
        if (!shouldKeepScore) return;
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
