using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeSkin : MonoBehaviour, IStoreClient
{

    [SerializeField] private SpriteRenderer Shirt;
    [SerializeField] private SpriteRenderer Hood;

    /// <summary>
    /// Check if the player has enough money to buy
    /// </summary>
    /// <param name="coinsAmount"></param>
    /// <returns></returns>
    public bool HasCoinsToBuy(int coinsAmount)
    {
        if(GameManager.Instance.GetCoinsAmount() >=  coinsAmount)
        {
            GameManager.Instance.ReduceCoins(coinsAmount);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Change the player outfit when bought
    /// </summary>
    /// <param name="shopItem"></param>
    public void ItemPurchased(SOClothPart shopItem)
    {
        switch(shopItem.itemType)
        {
            case "Hood":     Hood.sprite = shopItem.itemSprite; break;
            case "Shirt":     Shirt.sprite = shopItem.itemSprite; break;
        }

    }



}
