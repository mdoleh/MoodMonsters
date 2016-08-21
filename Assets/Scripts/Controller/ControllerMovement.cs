using System.Collections;
using Globals;
using HelpGUI;
using UnityEngine;

public class ControllerMovement : MonoBehaviour 
{
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
    private GameObject disablePanel;
    private GameObject noInputSymbol;
    private Canvas helpCanvas;

    protected virtual void Start()
    {
        joystickInstructions = joystickCanvas.GetComponent<AudioSource>();
        disableJoystickPanel = joystickCanvas.transform.FindChild("DisablePanel").gameObject;
        joystickScript = joystickCanvas.transform.FindChild("Base").FindChild("Stick").GetComponent<Joystick>();
        helpCanvas = GameObject.Find("HelpCanvas").GetComponent<Canvas>();
        disablePanel = helpCanvas.transform.FindChild("DisablePanel").gameObject;
        noInputSymbol = disablePanel.transform.FindChild("NoInputSymbol").gameObject;
    }

    protected virtual void Update()
    {
        if (isWalking)
        {
            if (trackJoystick)
            {
                movementHandler.HandleMovement(joystickScript);
                multiplierSpeed = joystickScript.CurrentSpeedAndDirection.y;
                multiplierDirection = joystickScript.CurrentSpeedAndDirection.x;
            }
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
