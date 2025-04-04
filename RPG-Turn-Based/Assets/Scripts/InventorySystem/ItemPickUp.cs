using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    public InputRef inputRef;

    private void Awake()
    {
        inputRef.PickUpItemEvent += InteractItem;
    }
    
    //Provisório, até termos um botão de interect genérico
    private void InteractItem()
    {
        Debug.Log("Clicou");
        InventoryManager.inventoryManager.Add(item);
        Destroy(gameObject);
    }

}
