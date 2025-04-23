using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager hudManager;

    public Text playerName;
    public Slider playerHpBar;
    public Slider playerManaBar;
    
    private void Awake()
    {
        hudManager = this;
    }

    public void UpdatePlayerHP(int hpHudValue)
    {
        playerHpBar.value = hpHudValue;
    }

    public void UpdatePlayerMana(int manaHudValue)
    {
        playerManaBar.value = manaHudValue;
    }
}
