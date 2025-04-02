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

   //variaveis de calculo auxiliar 
    [Header("Gravity")]
    public float gravityMutiplier;
    public float gravity;
    public float fallVelocity;

    [Space(20)]

    //variaveis de calculo auxilar do jump
    [Header("Jump")]
    public Vector3 jumpHeigth;
    public float jumpTime;
    public float jumpForce;
    public bool jumping;
   
}
