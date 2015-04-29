using UnityEngine;
using System.Collections;
using ScaredScene;

public class FearlessMovement : CharacterMovement
{
    public Camera mainCamera;
    public CameraFollow cameraFollow;
    public Canvas joystick;
    private GameObject otherCharacter;

    protected override void Start()
    {
        base.Start();
        otherCharacter = GameObject.Find("Aj");
    }

    public override void StartWalking()
    {
        base.StartWalking();
        otherCharacter.GetComponent<CharacterMovement>().StartWalking();
    }

    public override void TurnAround()
    {
        resetCamera();
        base.TurnAround();
        otherCharacter.GetComponent<CharacterMovement>().Run();
    }

    public override void Run()
    {
        adjustCamera();
        base.Run();
        otherCharacter.GetComponent<CharacterMovement>().StartWalking();
    }

    private void adjustCamera()
    {
        cameraFollow.enabled = false;
        joystick.GetComponent<Canvas>().enabled = true;
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y + 2.9f, transform.position.z + 0.3f);
        mainCamera.transform.localRotation = Quaternion.Euler(33.56473f, 98.39697f, 5.486476f);
    }

    private void resetCamera()
    {
        cameraFollow.enabled = true;
        joystick.GetComponent<Canvas>().enabled = true;
        mainCamera.transform.position = new Vector3(cameraFollow.gameObject.transform.position.x, 6.95f, 163.25f);
        mainCamera.transform.localRotation = Quaternion.Euler(4.587073f, 1.254006f, 0.08177387f);
    }
}
