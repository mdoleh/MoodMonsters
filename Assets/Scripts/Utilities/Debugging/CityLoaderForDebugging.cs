using Globals;
using UnityEngine;

// Used only by the Editor when starting a scene without
// first hitting the Title Screen to make debugging scenes easier
// Individual scenes do not load the City in real play-throughs, it is loaded in advance on the Title Screen
public class CityLoaderForDebugging : MonoBehaviour {

	void Start ()
	{
        if (CityInitializer.City == null) 
            Application.LoadLevelAdditive("SmallCityForDebugging");
	}
}
