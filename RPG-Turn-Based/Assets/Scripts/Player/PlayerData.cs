using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// Script de data para guardar valores e metódos de auxilo do player, como valores de status
/// checagens em geral, funções prontas e acessores de permissão.
/// </summary>

[CreateAssetMenu(menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("PlayerStats")] [Space(10)]
    public float health;
    public float movSpeed = 10;
    public float rotationSpeed;

    //variaveis de calculo auxiliares de gravidade
    [Header("Gravity")] [Space(10)]
    public float gravity = -9.81f;
    public float groundedGravity = -.05f;

    [Space(20)]

    //variaveis de calculo auxilar do jump
    [Header("Jump")] [Space(10)]
    public float jumpHeigth;
    public float initialJumpVelocity;
    public bool isJumping;
   
    //Método auxilar para a lógica do jump
    public void SetupAuxJump()
    {
        float jumpTime = jumpHeigth / 2;
        gravity = (-2 * jumpHeigth) / Mathf.Pow(jumpTime, 2);
        initialJumpVelocity = (2 * jumpHeigth) / jumpTime;     
    }
}
