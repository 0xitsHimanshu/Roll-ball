using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text CoinText; 
    [SerializeField] float RotateCoinSpeed = 10f;

//   public void IncrementToken()
//     {
//         if (FindObjectOfType<GameManager>().gameHasEnded == false)       //If the game is not over
//         {
//             PlayerPrefs.SetInt("Token", PlayerPrefs.GetInt("Token", 0) + 1);        //Increases the number of tokens
//             CoinText.text = PlayerPrefs.GetInt("Token", 0).ToString();     //Writes out the number of tokens to the screen
//             //tokenTextAnim.Play();       //Plays tokenTextAnim
//             //FindObjectOfType<AudioManager>().TokenSound();      //Plays tokenSound
//         }
//     }

    void Awake()
    {
        CoinText.text = PlayerPrefs.GetInt("Token",0).ToString();
    }

    void Update() 
    {
        transform.Rotate(0,RotateCoinSpeed,0,Space.World);
    }
    void OnTriggerEnter(Collider other)
    {
        // int score = int.Parse (CoinText.text) + 1;
       //CoinText.text = score.ToString();
        PlayerPrefs.SetInt("Token", PlayerPrefs.GetInt("Token", 0) + 1);
        CoinText.text = PlayerPrefs.GetInt("Token", 0).ToString();
        Destroy(gameObject);
    }
    public void DecrementToken(int decreaseValue)
    {
        PlayerPrefs.SetInt("Token", PlayerPrefs.GetInt("Token", 0) - decreaseValue);//Decreases the number of tokens by decreaseValue
        CoinText.text = PlayerPrefs.GetInt("Token", 0).ToString();     //Writes out the number of tokens to the screen
    }  

}
