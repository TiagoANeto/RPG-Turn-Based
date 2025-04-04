using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Componentes necessários para o uso do player e acesso a seus valores, variaveis e inputs
/// </summary>
[RequireComponent(typeof(CharacterController))] [RequireComponent(typeof(PlayerData))] [RequireComponent(typeof(InputRef))]
public class Player : MonoBehaviour
{   
    #region Declarações
    private Vector2 input;
    private Vector3 movement;
    private Animator animator;
    private CharacterController cc;

    [Header("Referências de Componente")]
    public InputRef inputRef;
    public PlayerData data;

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
        cc.Move(movement * data.movSpeed * Time.deltaTime); 

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
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, data.rotationSpeed * Time.deltaTime);
        }
    }

    private void Gravity()
    {   
        if(cc.isGrounded)
        {
            input.y = data.groundedGravity;
        }
        else
        {
            float previousYvelocity = input.y;
            float newYvelocity = input.y + (data.gravity * Time.deltaTime);
            float nextYvelocity = (previousYvelocity + newYvelocity) * .5f;
            input.y = nextYvelocity;

        }
    }
}
