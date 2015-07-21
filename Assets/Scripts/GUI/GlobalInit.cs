using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Globals;

public class GlobalInit : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    Timeout.ResetValues();
        GameFlags.ResetValues();
        Scenes.ResetValues();
        Attempts.ResetValues();
        Help.ResetValues();
        Sound.ResetValues();
	}
}
