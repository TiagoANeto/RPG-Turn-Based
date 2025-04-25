using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager hudManager;

    [Header("Player Display Info")] [Space(10)]
    public Text playerName;
    public Text playerLevel;
    public Slider playerHpBar;
    public Slider playerManaBar;

    [Header("Enemy Display Info")] [Space(10)]
    public Text enemyName;
    public Text enemyLevel;
    public Slider enemyHpBar;
    
    private void Awake()
    {
        hudManager = this;
    }

    public void UpdateHP(int hpHudValue)
    {
        playerHpBar.value = hpHudValue;
    }

    public void UpdateMana(int manaHudValue)
    {
        playerManaBar.value = manaHudValue;
    }
}
