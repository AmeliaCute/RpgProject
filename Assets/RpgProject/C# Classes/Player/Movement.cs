using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private CharacterController Controller;
    [SerializeField] private RectTransform EnduranceBar;

    [SerializeField] private float WalkingSpeed = 5f;
    [SerializeField] private float SprintingSpeed = 7f;

    [SerializeField] private float MaxEndurance = 500f;
    [SerializeField] private float ActualEndurance;

    private bool isSprinting = false;
    private float TargetAngleSmoothTime = 0.1f;
    private float TargetAngleSmoothVelocity;

    private void Start()
    {
        ActualEndurance = MaxEndurance;
        EnduranceBar.sizeDelta = new Vector2(ActualEndurance/2, 14f);
        EnduranceBar.transform.position = new Vector3(0f, 18, 0);
    }
    void Update()
    {
        //Sprinting
        if (Input.GetButtonDown("Sprint"))
            if (isSprinting != true)  
                   isSprinting = true;
        if (Input.GetButtonUp("Sprint"))
            if(isSprinting != false)
                isSprinting = false;

        //Gravity
        Vector3 moveVector = Vector3.zero;
        if (Controller.isGrounded == false)
            moveVector += Physics.gravity;
        Controller.Move(moveVector * Time.deltaTime);

        //Moving
        float AxisHor = Input.GetAxisRaw("Horizontal");
        float AxisVer = Input.GetAxisRaw("Vertical");
        Vector3 Direction = new Vector3(AxisHor, 0f, AxisVer).normalized;

        if (Direction.magnitude >= 0.1f)
        {
            float speed = WalkingSpeed;
            if (isSprinting)
            {
                if(ActualEndurance != 0)
                    speed = SprintingSpeed;
                if (ActualEndurance > 0)
                    ActualEndurance--;
            }
            else
            {
                if (ActualEndurance < MaxEndurance)
                {
                    ActualEndurance++;
                }
            }

            float TargetAngle = Mathf.Atan2(-Direction.z, Direction.x) * Mathf.Rad2Deg;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref TargetAngleSmoothVelocity, TargetAngleSmoothTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);

            Controller.Move(Direction * speed * Time.deltaTime);
        }
        else //Endurance
        {
            if (ActualEndurance < MaxEndurance)
            {
                ActualEndurance++;
            }
        }
        EnduranceBar.sizeDelta = new Vector2(ActualEndurance/2, 14f);
    }
}
