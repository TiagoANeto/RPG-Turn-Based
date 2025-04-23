using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager gameManager;
   public GameObject panelMenuInGame;
   public InputRef inputRef;

   private void Awake()
   {
        inputRef.OpenMenuInGameEvent += MenuInGame;

        if(gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
   }

    private void MenuInGame()
    {
        panelMenuInGame.SetActive(!panelMenuInGame.activeInHierarchy);
    }
}
