using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour, IMovement
{
    [Header("Valores do Player")]
    [field: SerializeField] public float movSpeed { get; set;} = 7;
    public float rotationSpeed;
    private Vector2 input;
    private Vector3 movement;
    private Vector3 rotate;
    public CharacterController cc { get; set;}
    public InputRef inputRef;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();

        inputRef.MoveEvent += Move;
    }

    private void Update()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        cc.Move(movement * movSpeed * Time.deltaTime); 
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
}
