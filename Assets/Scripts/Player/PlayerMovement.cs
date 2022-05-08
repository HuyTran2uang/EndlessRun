using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : UpdateMonoBehaviour
{
    public float MoveSpeed;
    public float JumpHeight;

    public Transform PlayerSensor;
    public float GroundDistance;
    public LayerMask GroundMask;

    public Vector3 Velocity;
    public const float GRAVITY = -9.8f;
    public bool IsGrounded;
    public bool IsMoving;

    public float InputX;
    public bool IsJumpPressed;

    protected virtual void Start()
    {
        MoveSpeed = 5.0f;
        JumpHeight = 4.0f;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadComponentGravity();
    }

    protected virtual void LoadComponentGravity()
    {
        PlayerSensor = GameObject.FindObjectOfType<PlayerSensor>().GetComponent<Transform>();
        GroundDistance = 0.4f;
        GroundMask = LayerMask.GetMask("Ground");
    }

    protected override void Update()
    {
        base.Update();
        Gravity();
        Jump();
    }

    protected override void InputManager()
    {
        base.InputManager();

        InputX = Input.GetAxisRaw("Horizontal");
        IsJumpPressed = Input.GetKey(KeyCode.K);
    }

    protected virtual void FixedUpdate()
    {
        Velocity.x = InputX * MoveSpeed;
        Velocity.y += GRAVITY * Time.deltaTime;
        Velocity.z = MoveSpeed;
        PlayerController.Instance.CharacterController.Move(Velocity * Time.deltaTime);
    }

    protected virtual void Gravity()
    {
        IsGrounded = Physics.CheckSphere(PlayerSensor.position, GroundDistance, GroundMask);
        if (IsGrounded && Velocity.y < 0) Velocity.y = 0;
    }

    protected virtual void Jump()
    {
        if (!IsJumpPressed) return;
        IsJumpPressed = false;
        if (!IsGrounded) return;
        Velocity.y = Mathf.Sqrt(JumpHeight * -2f * GRAVITY);
    }
}
