using UnityEngine;
using UnityEngine.UI;

public class BattleHUDControl : MonoBehaviour
{

    [Header("Characters Display Info")] [Space(10)]
    public Text nameText;
    public Text levelText;
    public Slider hpBar;
    public Slider manaBar;

    public void SetHud(CharacterStats characterStats)
    {
        nameText.text = characterStats.characterName;
        levelText.text = "Level " + characterStats.level;
        hpBar.maxValue = characterStats.maxHp;
        hpBar.value = characterStats.hp;
        manaBar.value = characterStats.mana;
    }

    public void UpdateHP(int hpHudValue)
    {
        hpBar.value = hpHudValue;
    }

    public void UpdateMana(int manaHudValue)
    {
        manaBar.value = manaHudValue;
    }
}
