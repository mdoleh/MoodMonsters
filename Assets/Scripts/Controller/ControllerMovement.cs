using System.Collections;
using Globals;
using HelpGUI;
using UnityEngine;

public class ControllerMovement : MonoBehaviour 
{
    // MovementHandler script exists on the GameObject being controlled by the joystick
    // responsible to customizing how the joystick should impact the model's movement
    // (ex: Luis, AJ, Skeeball)
    public MovementHandler movementHandler;
    public GameObject joystickCanvas;
    public Camera mainCamera;
    public GameObject[] joystickAnimations;
    public AudioSource initialInstructions;

    protected bool isWalking = false;
    protected float multiplierSpeed = 2f;
    protected float multiplierDirection = 0f;
    protected bool trackJoystick = false;
    protected AudioSource joystickInstructions;
    protected Joystick joystickScript;

    private bool initialInstructionsPlayed = false;
    private GameObject disableJoystickPanel;

    protected virtual void Start()
    {
        joystickInstructions = joystickCanvas.GetComponent<AudioSource>();
        disableJoystickPanel = joystickCanvas.transform.FindChild("DisablePanel").gameObject;
        joystickScript = joystickCanvas.transform.FindChild("Base").FindChild("Stick").GetComponent<Joystick>();
    }

    // Where movement behavior is controlled
    protected virtual void Update()
    {
        if (isWalking)
        {
            // controls the speed and direction of the model that
            // is being controlled with the joystick
            if (trackJoystick)
            {
                multiplierSpeed = joystickScript.CurrentSpeedAndDirection.y;
                multiplierDirection = joystickScript.CurrentSpeedAndDirection.x;
                movementHandler.HandleMovement(joystickScript);
            }
            // default movement that should occur when the joystick is not being tracked
            else
            {
                movementHandler.OverrideMovement(Time.deltaTime*multiplierSpeed, Time.deltaTime*multiplierDirection);
            }
        }
    }

    public virtual void StartRunningAnimation() {}

    protected virtual void StartJoystickTutorial()
    {
        StartCoroutine(PlayJoystickInstructions());
    }

    // Primary method that controls when the joystick should appear
    // and if the instructions audio clips should play
    protected virtual IEnumerator PlayJoystickInstructions()
    {
        DisableHelpGUI();
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
        Timeout.StartTimers();
        multiplierSpeed = 0f;
        multiplierDirection = 0f;
        isWalking = true;
    }

    protected void HideJoystick(bool shouldStartTimers)
    {
        joystickCanvas.GetComponent<Canvas>().enabled = false;
        joystickScript.shouldStartTimers = shouldStartTimers;
    }

    protected void ShowJoystick()
    {
        joystickCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void DisableHelpGUI()
    {
        HelpCanvas.Interactive(false);
    }

    public void EnableHelpGUI()
    {
        HelpCanvas.EnableHelpCanvas(true);
        HelpCanvas.Interactive(true);
    }

    protected void ResetAndDisableJoystick()
    {
        trackJoystick = false;
        joystickScript.ButtonRelease();
        disableJoystickPanel.SetActive(true);
    }
}
