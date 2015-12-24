using System.Collections;
using Globals;
using UnityEngine;

public class ControllerMovement : MonoBehaviour 
{
    public MovementHandler movementHandler;
    public GameObject joystickCanvas;
    public Camera mainCamera;
    public float zMax = 80.767f;
    public float zMin = 80.366f;
    public GameObject[] joystickAnimations;
    public AudioSource initialInstructions;

    protected bool isWalking = false;
    protected float multiplierSpeed = 2f;
    protected float multiplierDirection = 0f;
    protected bool trackJoystick = false;
    
    private bool initialInstructionsPlayed = false;
    private AudioSource joystickInstructions;
    private GameObject disableJoystickPanel;
    private Joystick joystickScript;
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
                movementHandler.HandleMovement(joystickScript);
            else
                movementHandler.OverrideMovement(Time.deltaTime * multiplierSpeed, Time.deltaTime * multiplierDirection);
        }
    }

    public virtual void StartRunningAnimation() {}

    protected virtual void AdjustCamera()
    {
        if (!joystickCanvas.activeInHierarchy) GUIHelper.NextGUI();
        joystickCanvas.GetComponent<Canvas>().enabled = true;
        mainCamera.transform.position = new Vector3(transform.position.x - 1.0f, transform.position.y + 3.0f, transform.position.z + 0.3f);
        mainCamera.transform.localRotation = Quaternion.Euler(33.56473f, 98.39697f, 5.486476f);
    }

    protected virtual void StartJoystickTutorial()
    {
        StartCoroutine(playJoystickInstructions());
    }

    private IEnumerator playJoystickInstructions()
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
        disablePanel.SetActive(true);
        noInputSymbol.SetActive(true);
    }

    public void EnableHelpGUI()
    {
        helpCanvas.enabled = true;
        disablePanel.SetActive(false);
    }

    protected void ResetAndDisableJoystick()
    {
        trackJoystick = false;
        joystickScript.ButtonRelease();
        disableJoystickPanel.SetActive(true);
    }
}
