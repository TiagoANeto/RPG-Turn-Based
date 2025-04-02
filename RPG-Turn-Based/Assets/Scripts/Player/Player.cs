using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [Header("Valores do Player")] [Space(10)]
    public float movSpeed = 10;
    public float rotationSpeed;
    private Vector2 input;
    private Vector3 movement;
    private Animator animator;
    public CharacterController cc;
    public InputRef inputRef;
    public PlayerData data;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        inputRef.MoveEvent += Move;
        inputRef.JumpEvent += Jump;
    }

    private void Update()
    {
        Movement();
        Rotation();
        Gravity();
    }

    private void Movement()
    {
        cc.Move(movement * movSpeed * Time.deltaTime); 

        if(movement.magnitude > 0.1f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void Move(Vector2 movDir)
    {
        input = movDir;
        movement = new Vector3(input.x, 0f, input.y);
    }

    private void Rotation()
    {
        if(movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void Gravity()
    {
        cc.Move(data.fallVelocity * Vector3.up);

        if(cc.isGrounded && data.fallVelocity < 0.0f)
        {
            data.fallVelocity = 0.0f;
            
        }
        else
        {
            data.fallVelocity += data.gravity * data.gravityMutiplier * Time.deltaTime;
        }
    }

    private void Jump()
    {
        if(cc.isGrounded && !data.jumping)
        {
            data.jumpHeigth = new Vector3(0f, data.jumpForce, 0f);
            cc.Move(data.jumpHeigth * data.jumpForce * Time.deltaTime);
        }
    }
}
