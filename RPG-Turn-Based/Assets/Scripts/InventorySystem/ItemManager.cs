using UnityEngine;

public class ItemManager : MonoBehaviour, IInteractable
{
    public Item item;
    public InputRef inputRef;

    private void Awake()
    {
        inputRef.InteractEvent += CollectItem;
    }

    public void Interact()
    {
        CollectItem();
    }

    private void CollectItem()
    {
        Debug.Log("Interagiu com o item");
        InventoryManager.inventoryManager.Add(item);
        Destroy(gameObject);
    }
}
