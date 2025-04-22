using UnityEngine;

/// <summary>
/// Classe responsavel pelos status de cada personagem que pode estar em combate,
/// seja ele player ou inimigo.
/// </summary>
[CreateAssetMenu(fileName = "New Character", menuName = "Create new Character/Character")]
public class CharacterStats : ScriptableObject
{
    public int hp;
    public int mana;
    public string characterName;
    public int damage;
    public int level;
}
