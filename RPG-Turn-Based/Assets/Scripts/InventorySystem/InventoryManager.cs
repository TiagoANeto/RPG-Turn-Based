using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventoryManager;
    public List<Item> Items = new List<Item>();
    public Transform ItemContent;
    public GameObject InventoryItems;

    private void Awake()
    {
        inventoryManager = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItems, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;

        }
    }
}
