using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject panelSettings;
    public string sceneName;

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Settings()
    {
        panelSettings.SetActive(!panelSettings.activeInHierarchy);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
