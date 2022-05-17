using UnityEngine;
using TMPro;

public class SkinManager : MonoBehaviour
{
    [SerializeField] GameObject[] skins , LockskinImage;
    [SerializeField] int[] requiredCoinsToUnlock;
    [SerializeField] TextMeshProUGUI[] requiredCoinText;
    [SerializeField] GameObject NotEnoughCointext;

    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("skin1Unlocked",1);
        SkinCheck();
        IntializeRequiredCoinTexts();
    }

    public void  IntializeRequiredCoinTexts()
    {
        for (int i = 0; i < requiredCoinText.Length; i++)
            requiredCoinText[i].text = requiredCoinText[i].ToString();
    }

    public void SkinCheck()
    {
        for (int i = 0; i < LockskinImage.Length; i++)
        {
            if (PlayerPrefs.GetInt("Skin" + (i+1) .ToString() + "Unlocked",0) ==1)
                LockskinImage[i].SetActive(false);            
        }
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;   //Next skin's position is the same as the temporary one's
        Destroy(GameObject.FindGameObjectWithTag("Player"));        //Destroys the current skin
        Instantiate(skins[PlayerPrefs.GetInt("Skin", 0)], playerPos, Quaternion.identity);  //Spawns the selected skin
    }
    
    public void Skin1()
    {
        if (PlayerPrefs.GetInt("Skin1Unlocked", 0) == 0)        //If the skin is not unlocked yet
        {
            if (PlayerPrefs.GetInt("Token", 0) < requiredCoinsToUnlock[0])       //If the skin cannot be unlocked
            {
                NotEnoughCointext.SetActive(true);       //Plays the animation of notEnoughTokensText
                //FindObjectOfType<AudioManager>().NotEnoughTokenSound();     //Plays notEnoughTokenSound
            }
            else    //If the skin can be unlocked
            {
                PlayerPrefs.SetInt("Skin1Unlocked", 1);     //Unlocks skin
                FindObjectOfType<ScoreManager>().DecrementToken(requiredCoinsToUnlock[0]);     //Decrements the count of tokens by requiredTokensToUnlock's value
                PlayerPrefs.SetInt("Skin", 0);
                SkinCheck();        //Enables the selected skin
                //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
            }
        }
        else    //If the skin is unlocked
        {
            PlayerPrefs.SetInt("Skin", 0);
            SkinCheck();        //Enables the selected skin
            //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
        }
    }

    public void Skin2()
    {
        if (PlayerPrefs.GetInt("Skin2Unlocked", 0) == 0)        //If the skin is not unlocked yet
        {
            if (PlayerPrefs.GetInt("Token", 0) < requiredCoinsToUnlock[0])       //If the skin cannot be unlocked
            {
                NotEnoughCointext.SetActive(true);       //Plays the animation of notEnoughTokensText
                //FindObjectOfType<AudioManager>().NotEnoughTokenSound();     //Plays notEnoughTokenSound
            }
            else    //If the skin can be unlocked
            {
                PlayerPrefs.SetInt("Skin2Unlocked", 1);     //Unlocks skin
                FindObjectOfType<ScoreManager>().DecrementToken(requiredCoinsToUnlock[0]);     //Decrements the count of tokens by requiredTokensToUnlock's value
                PlayerPrefs.SetInt("Skin", 0);
                SkinCheck();        //Enables the selected skin
                //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
            }
        }
        else    //If the skin is unlocked
        {
            PlayerPrefs.SetInt("Skin", 0);
            SkinCheck();        //Enables the selected skin
            //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
        }
    }


}
