using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIspaused = false;
    [SerializeField] GameObject PauseMenuUI, JoystickUI , _TouchZoneUI;
    
    void Update()
    {      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIspaused)
            {
                Resume();
            }
            else
            {
                Pause();    
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Game is Resumed");
        PauseMenuUI.SetActive(false);
        JoystickUI.SetActive(true);
        _TouchZoneUI.SetActive(true);
        Time.timeScale = 1f;
        GameIspaused = false;
    }

    void Pause()
    {
        Debug.Log("Game is Paused");
        PauseMenuUI.SetActive(true);
        JoystickUI.SetActive(false);
        _TouchZoneUI.SetActive(false);
        
        Time.timeScale = 0f;
        GameIspaused = true;
    }

    public void Loadmenu(string sceneName)
    {
        Debug.Log("Load menu");
        LevelManager.Instance.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    /* From here we start the Level completion UI button functioning code which is Home -- Next -- Repeat */
    public void LoadNextlevel(string NextSceneName)
    {
        Debug.Log("Loading Next Level");
       LevelManager.Instance.LoadScene(NextSceneName);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadingSameScene()
    {
        Debug.Log("Loading Same Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    
}
