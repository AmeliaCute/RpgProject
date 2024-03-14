using UnityEngine;
using UnityEngine.InputSystem;

public class EnduranceTaskPlayer : MonoBehaviour
{
    public Vector3 taskPos;
    
    void Start()
    {
        // Place the player at the task position
        float movementAmount = -1 * 10 * Time.deltaTime;
        transform.Translate(Vector3.right * movementAmount);
        Vector3 offset = transform.position - taskPos;
        offset = offset.normalized * 2;
        transform.position = taskPos + offset;
        transform.LookAt(taskPos);
    }

    void Update()
    {
        Movements();
    }

    public void Movements()
    {
        float inputVector = FindObjectOfType<PlayerInput>().actions.FindActionMap("EnduranceTask").FindAction("Direction").ReadValue<float>();

        if (inputVector != 0)
        {
                float movementAmount = inputVector * 10 * Time.deltaTime;

                transform.Translate(Vector3.right * movementAmount);
                Vector3 offset = transform.position - taskPos;
                offset.y = 0f;
                offset = offset.normalized * 2;
                transform.position = taskPos + offset;

                transform.LookAt(taskPos);
        }
    }
}
