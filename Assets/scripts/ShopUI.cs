using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace ShopUpgradeSystem
{
    public class ShopUI : MonoBehaviour
    {
         private int totalCoins;
        [SerializeField] private SaveLoadData saveLoadData;
        public GameObject[] SkinList;                       //list to all the 3D models of items
        public ShopData shopData;                 //ref to ShopSaveScriptable asset
        public TMP_Text unlockBtnText,SkinNameText, totalCoinsText; //ref to important text components
       // public Text speedText, accelerationText, ;
        public Button unlockBtn,nextBtn, previousButton;   //ref to important Buttons
        private int currentIndex = 0;                       //index of current item showing in the shop 
        public int selectedIndex;                          //actual selected item index

        private void Start()
        {
            //saveLoadData.Initialize();                      //Initialize , load or save default data and load data
            totalCoins = PlayerPrefs.GetInt("Token", 0);
            selectedIndex = PlayerPrefs.GetInt("SelectedItem", 0);  //get the selectedIndex from PlayerPrefs
            currentIndex = selectedIndex;                           //set the currentIndex
            totalCoinsText.text = "" + totalCoins;
            SetCarInfo();

            unlockBtn.onClick.AddListener(() => UnlockSelectButton());      //add listner to button
            //upgradeBtn.onClick.AddListener(() => UpgradeButton());          //add listner to button
            nextBtn.onClick.AddListener(() => NextButton());                //add listner to button
            previousButton.onClick.AddListener(() => PreviousButton());     //add listner to button

            if (currentIndex == 0) previousButton.interactable = false;     //dont interact previousButton if currentIndex is 0
            //dont interact previousButton if currentIndex is shopItemList.shopItems.Length - 1
            if (currentIndex == shopData.shopItems.Length - 1) nextBtn.interactable = false;

            SkinList[currentIndex].SetActive(true);                         //activate the object at currentIndex
            UnlockButtonStatus();                                           
            //UpgradeButtonStatus();
        }

        void SetCarInfo()
        {
            SkinNameText.text = shopData.shopItems[currentIndex].SkinName;
        }    
        /// <summary>
        /// Method called on Next button click
        /// </summary>
        private void NextButton()
        {
            //check if currentIndex is less than the total shope items we have - 1
            if (currentIndex < shopData.shopItems.Length - 1)
            {
                SkinList[currentIndex].SetActive(false);                     //deactivate old model
                currentIndex++;                                             //increase count by 1
                SkinList[currentIndex].SetActive(true);                      //activate the new model
                SetCarInfo();                                               //set car information

                //check if current index is equal to total items - 1
                if (currentIndex == shopData.shopItems.Length - 1)
                {
                    nextBtn.interactable = false;                           //then set nextBtn interactable false
                }

                if (!previousButton.interactable)                           //if previousButton is not interactable
                {
                    previousButton.interactable = true;                     //then set it interactable
                }

                UnlockButtonStatus();
            }
        }

        /// <summary>
        /// Method called on Previous button click
        /// </summary>
        private void PreviousButton()
        {
            if (currentIndex > 0)                           //we check is currentIndex i more than 0
            {
                SkinList[currentIndex].SetActive(false);     //deactivate old model
                currentIndex--;                             //reduce count by 1
                SkinList[currentIndex].SetActive(true);      //activate the new model
                SetCarInfo();                               //set car information

                if (currentIndex == 0)                      //if currentIndex is 0
                {
                    previousButton.interactable = false;    //set previousButton interactable to false
                }

                if (!nextBtn.interactable)                  //if nextBtn interactable is false
                {
                    nextBtn.interactable = true;            //set nextBtn interactable to true
                }
                UnlockButtonStatus();
            }
        }

        /// <summary>
        /// Method called on Unlock button click
        /// </summary>
        private void UnlockSelectButton()
        {
            bool yesSelected = false;   //local bool
            if (shopData.shopItems[currentIndex].isUnlocked)//if shop item at currentIndex is already unlocked
            {
                yesSelected = true;                        //set yesSelected to true
            }
            else if (!shopData.shopItems[currentIndex].isUnlocked)//if shop item at currentIndex is not unlocked
            {
                //check if we have enough coins to unlock it
                if (totalCoins >= shopData.shopItems[currentIndex].unlockCost)
                {
                    //if yes then reduce the cost coins from our total coins
                    FindObjectOfType<ScoreManager>().DecrementToken(shopData.shopItems[currentIndex].unlockCost);
                    yesSelected = true;                             //set yesSelected to true
                    shopData.shopItems[currentIndex].isUnlocked = true; //mark the shop item unlocked
                
                }
            }

            if (yesSelected)
            {
                unlockBtnText.text = "EQUIPPED";                    //set the unlockBtnText text to Selected
                selectedIndex = currentIndex;                       //set the selectedIndex to currentIndex
                PlayerPrefs.SetInt("SelectedItem", selectedIndex);  //save the selectedIndex
                unlockBtn.interactable = false;                     //set unlockBtn interactable to false
            }
            
        }

        
        /// <summary>
        /// This method is called when we are changing the current item in the shop
        /// This method set the interactablity and text of unlock btn
        /// </summary>
        private void UnlockButtonStatus()
        {
            //if current item is unlocked
            if (shopData.shopItems[currentIndex].isUnlocked)
            {
                //if selectedIndex is not equal to currentIndex set unlockBtn interactable false else make it true
                unlockBtn.interactable = selectedIndex != currentIndex ? true : false;
                //set the text
                unlockBtnText.text = selectedIndex == currentIndex ? "EQUIPPED" : "EQUIP";
            }
            else if (!shopData.shopItems[currentIndex].isUnlocked) //if current item is not unlocked
            {
                unlockBtn.interactable = true;  //set the unlockbtn interactable
                unlockBtnText.text = shopData.shopItems[currentIndex].unlockCost + ""; //set the text as cost of item
            }
        }

         public void CloseSkinShop()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
