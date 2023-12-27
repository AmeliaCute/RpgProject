using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InputActionReference exit;
    [SerializeField] private Animator animator;
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
        animator.Play("InventoryMenuClose");
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}