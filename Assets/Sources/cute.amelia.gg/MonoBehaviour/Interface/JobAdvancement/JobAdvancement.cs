using System.Security;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class JobAdvancement : MonoBehaviour
{
    public static JobAdvancement instance = null;

    [SerializeField] private  InputActionReference exit;
    [SerializeField] private  Animator animator;
    [SerializeField] private  PlayerInput input;
    [SerializeField] private  Volume volume;
    [SerializeField] private  DepthOfField depthOfField;
    [SerializeField] private  Animator CameraAnimator;

    void Start()
    {
        CameraAnimator = FindObjectOfType<Camera>().GetComponent<Animator>();
        volume = FindObjectOfType<Volume>();
        input = FindObjectOfType<PlayerInput>();
        input.actions.FindActionMap("Player").Disable();
        input.actions.FindActionMap("JobAdvancement").Enable();
        volume.profile.TryGet(out depthOfField);
        depthOfField.active = true;
        instance = this;
    }

    void OnEnable()
    {
        exit.action.performed += exitWindow;
    }

    void OnDisable()
    {
        exit.action.performed -= exitWindow;
    }

    public void exitWindow(InputAction.CallbackContext context)
    {
        CameraAnimator.Play("CameraDezoom");
        animator.Play("JobAdvancementClose");
        input.actions.FindActionMap("JobAdvancement").Disable();
        input.actions.FindActionMap("Player").Enable();
        depthOfField.active = false;
    }

    public static void ForceExit()
    {
        instance.exitWindow(new InputAction.CallbackContext());
    }
}