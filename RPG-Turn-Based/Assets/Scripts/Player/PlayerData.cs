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
}
