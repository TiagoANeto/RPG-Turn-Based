using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public CharacterStats playerStats;

    private void Awake()
    {
        playerStats = GetComponent<CharacterStats>();
    }

    private void Start()
    {
        playerStats.hp = playerStats.maxHp;
        HUDManager.hudManager.playerHpBar.maxValue = playerStats.maxHp;
        HUDManager.hudManager.playerHpBar.value = playerStats.hp;
    }

    public void TakeDamage(int damageValue)
    {
        playerStats.hp -= damageValue;
        HUDManager.hudManager?.UpdatePlayerHP(playerStats.hp);

        if(playerStats.hp <= 0)
        {
            Destroy(gameObject);
            //Lógica de morte certinha tem que entrar aqui depois
        }
    }

    public void IncreaseHP(int value)
    {
        playerStats.hp += value;
        HUDManager.hudManager?.UpdatePlayerHP(playerStats.hp);
    }

    public void IncreaseMana(int value)
    {
        playerStats.mana += value;
        HUDManager.hudManager?.UpdatePlayerMana(playerStats.mana);
    }

    /// <summary>
    /// Botões para testes rápidos de coisas relacionadas a vida do boneco
    /// </summary>
    public void AddStatsHP()
    {
        playerStats.hp += 5;
        HUDManager.hudManager?.UpdatePlayerHP(playerStats.hp);
    }

    public void RemoveStatsHP()
    {
        playerStats.hp -=5;
        HUDManager.hudManager?.UpdatePlayerHP(playerStats.hp);
    }
}
