using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemShopInformation
{ 

    public enum ItemType
    {
        Hood,
        Gloves,
        Sleeves,
        Chest,
        Pants,
        Socks,
        Boots

    }

    public static int GetItemPrice(SOClothPart clothPart)
    {
        return clothPart.itemPrice;
    }




}
