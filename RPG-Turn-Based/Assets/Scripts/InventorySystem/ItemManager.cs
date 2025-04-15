using UnityEngine;

public class ItemManager : MonoBehaviour, IInteractable
{
    public Item item;

    public void Interact()
    {
        CollectItem();
    }

    private void CollectItem()
    {
        Debug.Log("Interagiu com o item");
        InventoryManager.inventoryManager.Add(item);
        InventoryManager.inventoryManager.ListItems();
        Destroy(gameObject);
    }
}
