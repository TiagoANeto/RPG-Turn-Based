using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// Componentes necessários para o uso do player e acesso a seus valores, variaveis e inputs
/// </summary>
[RequireComponent(typeof(CharacterController))] [RequireComponent(typeof(InputRef))]
public class Player : MonoBehaviour
{   
    #region Declarações
    private Vector2 input;
    private Vector3 movement;
    private Animator animator;
    private CharacterController cc;
    private bool _canInteract = false;
    private IInteractable interactable = null;
    

    [Header("PlayerMovementStats")] [Space(10)]
    public float movSpeed = 10;
    public float rotationSpeed = 7;

    //variaveis de calculo auxiliares de gravidade
    [Header("Gravity")] [Space(10)]
    public float gravity = -9.81f;
    public float groundedGravity = -.05f;

    [Header("Referências de Componente")]
    public InputRef inputRef;

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
        Interaction();
    }

    #region Métodos de Movimentação do Player
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
    #endregion

    #region Métodos de Interação do Player
    private void Interaction()
    {
        if(Keyboard.current.eKey.wasPressedThisFrame && _canInteract && interactable != null)
        {
            interactable.Interact();
            interactable = null;
            _canInteract = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrou na area de interacao");
        interactable = other.GetComponent<IInteractable>();
        _canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Saiu da area de interacao");
        _canInteract = false;
        interactable = null;
    }
    #endregion

}
