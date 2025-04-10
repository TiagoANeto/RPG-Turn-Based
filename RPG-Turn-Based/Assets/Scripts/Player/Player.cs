using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

/// <summary>
/// Componentes necessários para o uso do player e acesso a seus valores, variaveis e inputs
/// </summary>
[RequireComponent(typeof(CharacterController))] [RequireComponent(typeof(Character))] [RequireComponent(typeof(InputRef))]
public class Player : MonoBehaviour
{   
    #region Declarações
    private Vector2 input;
    private Vector3 movement;
    private Animator animator;
    private CharacterController cc;

    [Header("PlayerMovementStats")] [Space(10)]
    public float movSpeed = 10;
    public float rotationSpeed;

    //variaveis de calculo auxiliares de gravidade
    [Header("Gravity")] [Space(10)]
    public float gravity = -9.81f;
    public float groundedGravity = -.05f;

    [Header("Referências de Componente")]
    public InputRef inputRef;
    public CharacterStats playerStats;

    #endregion

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        //Atribução de eventos de input as ações do player
        inputRef.MoveEvent += Move;
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
        if(cc.isGrounded)
        {
            input.y = groundedGravity;
        }
        else
        {
            float previousYvelocity = input.y;
            float newYvelocity = input.y + (gravity * Time.deltaTime);
            float nextYvelocity = (previousYvelocity + newYvelocity) * .5f;
            input.y = nextYvelocity;

        }
    }
}
