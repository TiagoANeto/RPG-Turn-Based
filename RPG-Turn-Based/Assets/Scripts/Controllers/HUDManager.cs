using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager hudManager;

    public Text playerName;
    public Slider playerHpBar;
    public Slider playerManaBar;
    

    private void Awake()
    {
        if(hudManager == null)
        {
            hudManager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
