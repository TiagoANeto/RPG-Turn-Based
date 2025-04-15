using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public GameObject panelChest;
    
    public void Interact()
    {
        OpenChest();
    }

    private void OpenChest()
    {
        panelChest.SetActive(!panelChest.activeInHierarchy);
    }
}
