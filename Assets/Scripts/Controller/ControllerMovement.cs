using System;
using UnityEngine;
using System.Collections;
using Globals;

public class ControllerMovement : MonoBehaviour {

    public GameObject joystickCanvas;
    public Camera mainCamera;
    public float zMax = 80.767f;
    public float zMin = 80.366f;
    public GameObject[] joystickAnimations;
    public TutorialBase tutorial;
    public AudioSource initialInstructions;

    protected bool isWalking = false;
    protected float multiplierSpeed = 2f;
    protected float multiplierDirection = 0f;
    protected bool trackJoystick = false;
    
    private bool initialInstructionsPlayed = false;
    private AudioSource joystickInstructions;
    private GameObject disableJoystickPanel;
    private Joystick joystickScript;

    protected virtual void Start()
    {
        joystickInstructions = GameObject.Find("ControllerCanvas").GetComponent<AudioSource>();
        disableJoystickPanel = GameObject.Find("ControllerCanvas").transform.FindChild("DisablePanel").gameObject;
        joystickScript = joystickCanvas.GetComponentInChildren<Joystick>();
        tutorial.InitializeGameObjects();
    }

    protected virtual void Update()
    {
        if (isWalking)
        {
            float moveSpeed = Time.deltaTime * multiplierSpeed;
            float moveDirection = Time.deltaTime * multiplierDirection;
            transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z - moveDirection);
        }
        trackJoystickMovement();
    }

    private void trackJoystickMovement()
    {
        if (trackJoystick)
        {
            if (joystickScript.CurrentSpeedAndDirection.y > 0) StartRunningAnimation();
            multiplierSpeed = joystickScript.CurrentSpeedAndDirection.y;
            multiplierDirection = joystickScript.CurrentSpeedAndDirection.x;
            // limit character's position laterally (z-direction)
            if (transform.position.z > zMax)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
            }
            else if (transform.position.z < zMin)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zMin);
            }
            // limit character's position so it can't move behind the camera
            if (Math.Abs(mainCamera.transform.position.x - transform.position.x) < 1.0f)
            {
                transform.position = new Vector3(mainCamera.transform.position.x + 1.0f, transform.position.y, transform.position.z);
            }
        }
    }

    protected virtual void StartRunningAnimation() {}

    protected virtual void AdjustCamera()
    {
        if (GUIHelper.GetGUIByName(GUIHelper.CanvasList[0]).enabled)
        {
            GUIHelper.NextGUI();
        }
        else
        {
            joystickCanvas.GetComponent<Canvas>().enabled = true;
        }
        mainCamera.transform.position = new Vector3(transform.position.x - 1.0f, transform.position.y + 3.0f, transform.position.z + 0.3f);
        mainCamera.transform.localRotation = Quaternion.Euler(33.56473f, 98.39697f, 5.486476f);
    }

    protected virtual void StartJoystickTutorial()
    {
        StartCoroutine(playJoystickInstructions());
    }

    private IEnumerator playJoystickInstructions()
    {
        if (!initialInstructionsPlayed)
        {
            Utilities.PlayAudio(initialInstructions);
            if (initialInstructions != null)
            {
                yield return new WaitForSeconds(initialInstructions.clip.length);
            }
            initialInstructionsPlayed = true;
        }
        if (!GameFlags.JoyStickTutorialHasRun)
        {
            foreach (var joystickAnimation in joystickAnimations)
            {
                joystickAnimation.SetActive(true);
                var audio = joystickAnimation.GetComponent<AudioSource>();
                Utilities.PlayAudio(audio);
                yield return new WaitForSeconds(audio.clip.length);
                joystickAnimation.SetActive(false);
            }
            GameFlags.JoyStickTutorialHasRun = true;
        }
        EnableJoystick();
    }

    protected virtual void EnableJoystick()
    {
        disableJoystickPanel.SetActive(false);
        trackJoystick = true;
        EnableHelpGUI();
        Timeout.SetRepeatAudio(joystickInstructions);
        multiplierSpeed = 0f;
        multiplierDirection = 0f;
        isWalking = true;
    }

    protected void HideJoystick(bool shouldStartTimers)
    {
        joystickCanvas.GetComponent<Canvas>().enabled = false;
        joystickScript.shouldStartTimers = shouldStartTimers;
    }

    protected void DisableHelpGUI()
    {
        tutorial.DisableHelpGUI();
    }

    protected void EnableHelpGUI()
    {
        tutorial.EnableHelpGUI();
    }

    protected void ResetAndDisableJoystick()
    {
        trackJoystick = false;
        joystickScript.ButtonRelease();
        disableJoystickPanel.SetActive(true);
    }
}
