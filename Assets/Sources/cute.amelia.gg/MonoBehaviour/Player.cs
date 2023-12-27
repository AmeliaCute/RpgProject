using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private InputActionReference movement;
    [SerializeField] private float TargetAngleSmoothTime = 0.1f;
    [SerializeField] private List<JobInstance> Jobs;
    private float TargetAngleSmoothVelocity;


    

    void Update()
    {
        Movements();
    }

    void Movements()
    {
        Vector2 inputVector = movement.action.ReadValue<Vector2>();
        inputVector.Normalize();

        Vector3 movementVector = new Vector3(inputVector.x, 0f, inputVector.y);

        rigidbody.velocity = movementVector * 10;

        if (movementVector.magnitude > 0.1f)
        {
            float TargetAngle = Mathf.Atan2(-movementVector.z, movementVector.x) * Mathf.Rad2Deg;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref TargetAngleSmoothVelocity, TargetAngleSmoothTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);
        }
    }


}
