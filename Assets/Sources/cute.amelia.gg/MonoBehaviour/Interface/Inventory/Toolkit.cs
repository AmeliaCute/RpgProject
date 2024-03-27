using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Toolkit : MonoBehaviour
{
    [SerializeField] private InputActionReference exit;
    [SerializeField] private Animator animator;
    [SerializeField] private  Animator CameraAnimator;

    private PlayerInput input;
    private Volume volume;
    private DepthOfField depthOfField;
    void Start()
    {
        WidgetManagement.instance.ClosePanel();
        CameraAnimator = FindObjectOfType<Camera>().GetComponent<Animator>();
        volume = GameObject.FindObjectOfType<Volume>();
        input = GameObject.FindObjectOfType<PlayerInput>();
        input.actions.FindActionMap("Player").Disable();
        input.actions.FindActionMap("Inventory").Enable();
        volume.profile.TryGet(out depthOfField);
        depthOfField.active = true;
    }

    void OnEnable()
    {
        exit.action.performed += exitWindow;
    }

    void OnDisable()
    {
        exit.action.performed -= exitWindow;
    }

    private void exitWindow(InputAction.CallbackContext context)
    {
        WidgetManagement.instance.OpenPanel();
        CameraAnimator.Play("CameraDezoom");
        animator.Play("NewInventoryMenuClose");
        input.actions.FindActionMap("Inventory").Disable();
        input.actions.FindActionMap("Player").Enable();
        depthOfField.active = false;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}