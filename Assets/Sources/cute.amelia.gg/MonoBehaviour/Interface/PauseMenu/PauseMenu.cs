using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance = null;
    [SerializeField] private Player player;
    [SerializeField] private  InputActionReference exit;
    [SerializeField] private  Animator animator;
    [SerializeField] private  PlayerInput input;
    [SerializeField] private  Volume volume;
    [SerializeField] private  DepthOfField depthOfField;
    [SerializeField] private  Animator CameraAnimator;


    void Start()
    {
        WidgetManagement.instance.ClosePanel();
        player = FindObjectOfType<Player>();
        CameraAnimator = FindObjectOfType<Camera>().GetComponent<Animator>();
        CameraAnimator.Play("CameraZoom");
        volume = FindObjectOfType<Volume>();
        input = FindObjectOfType<PlayerInput>();
        input.actions.FindActionMap("JobAdvancement").Enable();
        input.actions.FindActionMap("Player").Disable();
        volume.profile.TryGet(out depthOfField);
        instance = this;
        depthOfField.active = true;
    }

    void OnEnable()
    {
        exit.action.performed += exitWindow;
         exit.action.performed += closeFR;
    }

    void OnDisable()
    {
        exit.action.performed -= exitWindow;
        exit.action.performed -= closeFR;
    }

    public void exitWindow(InputAction.CallbackContext context)
    {
        animator.Play("PauseMenuClose");
        input.actions.FindActionMap("JobAdvancement").Disable();
        input.actions.FindActionMap("Player").Enable();
        depthOfField.active = false;
    }

    private void closeFR(InputAction.CallbackContext context)
    {
        CameraAnimator.Play("CameraDezoom");
        WidgetManagement.instance.OpenPanel();
    }
    
    public static void ForceExit()
    {
        instance.exitWindow(new InputAction.CallbackContext());
    }
}