using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{   
    [SerializeField] GameObject LevelSelection_Screen;
    public void StartGame()
    {
        LevelSelection_Screen.SetActive(true);
    } 
    public void CloseLevel_selection()
    {
        LevelSelection_Screen.SetActive(false);
    }


     public void CloseSkinShop()
    {
        SceneManager.LoadScene("MainMenu");
    }

     public void StartSkinShop()
    {
        SceneManager.LoadScene("SkinShop");
    }
    public void ExitGame()
    {
        Debug.Log("Quiting!!!");
        Application.Quit();
    }
    public void PlayGame(string sceneName) 
    {
        LevelManager.Instance.LoadScene(sceneName);
        PauseMenu.GameIspaused = false;  
        //StartCoroutine(LoadMain(sceneName));
    }
}