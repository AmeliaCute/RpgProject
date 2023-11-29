using RpgProject.Game.Entity;
using UnityEngine;

public class EntityPlayer : Entity
{
    public override bool HasEndurance => true;
    public override string Name => "Player";
    public override string EntityMarker => "Player";

    public override float MaxHealth => 100;
    public override float MaxEndurance => 50;

    public float Speed = 5;
    private bool IsSprinting;
    private float TargetAngleSmoothTime = 0.1f;
    private float TargetAngleSmoothVelocity;

    public CharacterController CONTROLLER;

    public override void init()
    {
        CONTROLLER = gameObject.AddComponent<CharacterController>();
        CONTROLLER.center = new(0,0.4f, 0);
    }


    public override void update()
    {
        if(RpgClass.MODE_ETA == GAMEMODE.PLAYING)
        {
            Move();

            Vector3 moveVector = Vector3.zero;
            if (!CONTROLLER.isGrounded) moveVector += Physics.gravity;
            CONTROLLER.Move(moveVector * Time.deltaTime);
        }
    }

    private void Move()
    {
        float AxisHor = Input.GetAxisRaw("Horizontal");
        float AxisVer = Input.GetAxisRaw("Vertical");
        Vector3 Direction = new Vector3(AxisHor, 0f, AxisVer).normalized;

        if (Direction.magnitude >= 0.1f)
        {
            float speed = Speed;
            if (IsSprinting)
            {
                if (endurance != 0)
                    speed = (float)(Speed * 1.4);
                if (endurance > 0)
                    endurance -= 0.5f;
            }
            else
            if (endurance < MaxEndurance)
            {
                endurance++;
            }

            float TargetAngle = Mathf.Atan2(-Direction.z, Direction.x) * Mathf.Rad2Deg;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref TargetAngleSmoothVelocity, TargetAngleSmoothTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);

            CONTROLLER.Move(speed * Time.deltaTime * Direction);
        }
        else
        if (endurance < MaxEndurance)
        {
            endurance++;
        }
    }
}