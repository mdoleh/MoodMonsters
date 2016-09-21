using UnityEngine;
using System.Collections;

// Placed on a GameObject you want the camera to follow around in the x-direction
// (ex: AJ and Luis from the Scared and Sad Scenes respectively)
public class CameraFollow : MonoBehaviour
{
    public Transform mainCamera;

	void Update ()
	{
        mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.position.y, mainCamera.position.z);
	}
}
