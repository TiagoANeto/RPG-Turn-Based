using UnityEngine;

/// <summary>
/// Classe responsavel pelos status de cada personagem que pode estar em combate,
/// seja ele player ou inimigo.
/// </summary>
public class CharacterStats : MonoBehaviour
{
    public int hp;
    public int maxHp;
    public int mana;
    public string characterName;
    public int damage;
    public int level;
}
