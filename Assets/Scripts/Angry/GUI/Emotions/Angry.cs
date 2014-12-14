using UnityEngine;
using System.Collections;

public class Angry : ButtonDragDrop {

    GameObject[] GUI;

    public override void Awake()
    {
        base.Awake();
        GUI = GameObject.FindGameObjectsWithTag("GUI");
    }

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("Angry clicked");
    }

    public override void SubmitAnswer()
    {
        base.SubmitAnswer();
        Debug.Log("Angry submitted");
        StartGUI();
    }

    void StartGUI()
    {
        for (int ii = 0; ii < GUI.Length; ++ii)
        {
            if (GUI[ii].name == "PhysicalCanvas")
            {
                GUI[ii].GetComponent<Canvas>().enabled = true;
            }
            if (GUI[ii].name == "EmotionsCanvas")
            {
                GUI[ii].GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
