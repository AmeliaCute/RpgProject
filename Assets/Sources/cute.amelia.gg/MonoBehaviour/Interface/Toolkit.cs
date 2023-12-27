using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Toolkit : MonoBehaviour
{
    [SerializeField] private InputActionReference exit;
    [SerializeField] private Animator animator;
    private PlayerInput Input;
    void Start()
    {
        Input = GameObject.FindFirstObjectByType<PlayerInput>();
        Input.actions.FindActionMap("Player").Disable();
        Input.actions.FindActionMap("Inventory").Enable();
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
        animator.Play("ToolkitClose");
        Input.actions.FindActionMap("Inventory").Disable();
        Input.actions.FindActionMap("Player").Enable();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}