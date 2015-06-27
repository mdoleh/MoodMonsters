using Globals;
using UnityEngine;

public class SceneLoaderForDebugging : MonoBehaviour {

	void Start ()
	{
	    if (ScenePreloader.City == null) Application.LoadLevelAdditive("SmallCity");
	}
}
