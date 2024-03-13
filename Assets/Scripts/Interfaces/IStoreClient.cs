using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStoreClient 
{
    void ItemPurchased(SOClothPart shopItem);
    bool HasCoinsToBuy(int coinsAmount);

}
