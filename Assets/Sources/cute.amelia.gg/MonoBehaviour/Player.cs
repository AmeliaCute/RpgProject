using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    [SerializeField] public new Rigidbody rigidbody;
    [SerializeField] private InputActionReference movement;
    [SerializeField] private float TargetAngleSmoothTime = 0.1f;
    [SerializeField] private List<JobInstance> jobs;
    private float TargetAngleSmoothVelocity;

    void Update()
    {
        Movements();
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
    
    public void CopyStateFrom(Player otherPlayer)
    {
        rigidbody = otherPlayer.rigidbody;
        movement = otherPlayer.movement;

        jobs = otherPlayer.jobs;
        inventory = otherPlayer.inventory;

        health = otherPlayer.health;
        defense = otherPlayer.defense;
        attack = otherPlayer.attack;
        speed = otherPlayer.speed;
        level = otherPlayer.level;
    }
}
