using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public string itemName;
    public int itemValue;
    public int itemHarvestValue;    // how many instances of the item the player gets when collecting it off of the ground
    public bool hasBeenHarvested;   // makes sure that the player can't multiply the number of items by dropping and picking up again

    public enum item_rarity
    {
        UNITIALIZED,
        COMMON,
        UNCOMMON,
        RARE,
        ULTRA_RARE,
        LEGENDARY
    }
    public item_rarity itemRarity = item_rarity.UNITIALIZED;

    public enum item_type
    {
        UNITIALIZED,
        INGREDIENT,
        TOOL,
        WEAPON
    }
    public item_type itemType = item_type.UNITIALIZED;
}
