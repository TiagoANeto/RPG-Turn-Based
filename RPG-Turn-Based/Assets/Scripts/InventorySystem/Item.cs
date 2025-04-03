using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Create new item/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int itemValue;
    public Sprite itemIcon;
}
