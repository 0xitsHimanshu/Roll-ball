using UnityEngine;

namespace ShopUpgradeSystem
{
   [System.Serializable]
    public class ShopData
    {
        public ShopItem[] shopItems;
    }

    [System.Serializable]
    public class ShopItem
    {
        public string SkinName;             //name of item
        public bool isUnlocked;             //bool to check unlock status
        public int unlockCost;              //cost of unlock
    }
}