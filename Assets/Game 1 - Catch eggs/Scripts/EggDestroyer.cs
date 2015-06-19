using UnityEngine;
using System.Collections;

public class EggDestroyer : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        //Destroy this gameobject (and all attached components)
        Destroy(other.transform.parent.gameObject);
    }
}
