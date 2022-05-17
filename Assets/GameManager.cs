using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restarDelay = 1f;
    public GameObject CompleteLevelUI,VirtualJoystickUI , _TouchZoneUI; 
    
    public void CompletedLevel ()
    {
        CompleteLevelUI.SetActive(true);
        VirtualJoystickUI.SetActive(false);
        _TouchZoneUI.SetActive(false);  
    }

    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restarDelay); 
        }
            
    }
    
    void Restart ()
    {
        SceneManager.LoadScene("StartMenu");
    }

}
