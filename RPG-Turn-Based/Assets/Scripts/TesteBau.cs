using UnityEngine;

public class TesteBau : MonoBehaviour, IInteractable
{
    public GameObject panelBau;
    
    public void Interact()
    {
        AbrirBau();
    }

    private void AbrirBau()
    {
        panelBau.SetActive(!panelBau.activeInHierarchy);
    }
}
