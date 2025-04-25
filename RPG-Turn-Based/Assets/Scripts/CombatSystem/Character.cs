using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe refatorada para ser o Character e lidar com a vida, atk, def, morte e etc... de personagens jogáveis
/// inimigos e tudo que possa estar envolvido no combate
/// </summary>
public class Character : MonoBehaviour
{
    public CharacterStats characterStats;

    protected virtual void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    protected virtual void Start()
    {
        characterStats.hp = characterStats.maxHp;
    }

    protected virtual void TakeDamage(int damageValue)
    {
        characterStats.hp -= damageValue;
        
        if(characterStats.hp <= 0)
        {
            Destroy(gameObject);
            //Lógica de morte certinha tem que entrar aqui depois
        }
    }

    protected virtual void IncreaseHP(int value)
    {
        characterStats.hp += value;
    }

    protected virtual void IncreaseMana(int value)
    {
        characterStats.mana += value;
    }

    /// <summary>
    /// Botões para testes rápidos de coisas relacionadas a vida do boneco
    /// </summary>
    public void AddStatsHP()
    {
        characterStats.hp += 5;
    }

    public void RemoveStatsHP()
    {
        characterStats.hp -=5;
    }
}
