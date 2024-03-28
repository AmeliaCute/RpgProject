using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;

public class Player : Entity
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] public new Rigidbody rigidbody;
    [SerializeField] private InputActionReference movement;
    [SerializeField] private InputActionReference exit;
    [SerializeField] private float TargetAngleSmoothTime = 0.1f;
    [SerializeField] private JobManager jobManager;
    [SerializeField] private QuestManager questManager;
    private float TargetAngleSmoothVelocity;

    void Update()
    {
        Movements();
    }

    void OnEnable()
    {
        exit.action.performed += openPauseMenu;
    }

    void OnDisable()
    {
        exit.action.performed -= openPauseMenu;
    }

    void openPauseMenu(InputAction.CallbackContext context)
    {
        GameObject.Instantiate(pauseMenu, GameObject.FindGameObjectsWithTag("CANVAS")[0].GetComponent<Canvas>().transform);
    }

    public virtual void Movements()
    {
        Vector2 inputVector = movement.action.ReadValue<Vector2>();
        inputVector.Normalize();

        Vector3 movementVector = new Vector3(inputVector.x, 0f, inputVector.y);
        rigidbody.velocity = movementVector * speed.TotalValue;

        if (movementVector.magnitude > 0.1f)
        {
            float TargetAngle = Mathf.Atan2(-movementVector.z, movementVector.x) * Mathf.Rad2Deg;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref TargetAngleSmoothVelocity, TargetAngleSmoothTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);
        }
    }
    
    //NOTE - Useless ngl but maybe one day :)
    public void CopyStateFrom(Player otherPlayer)
    {
        rigidbody = otherPlayer.rigidbody;
        movement = otherPlayer.movement;

        inventory = otherPlayer.inventory;

        health = otherPlayer.health;
        defense = otherPlayer.defense;
        attack = otherPlayer.attack;
        speed = otherPlayer.speed;
        level = otherPlayer.level;
    }
}
