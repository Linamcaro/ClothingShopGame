using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    [SerializeField] private SOCloths shopItemList;
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private TextMeshProUGUI messageText;

    private Transform storePanel;
    private Transform storeTemplate;
    private float shopItemHeight = 20f; //Set the item position

    private IStoreClient storeClient;

    private void Awake()
    {
        
        storePanel = transform.Find("StorePanel");
        storeTemplate = storePanel.Find("StoreTemplate");
       

    }

    private void Start()
    {
        CreateItemButton();
    }
   
    private void CreateItemButton()
    {

        for (int item = 0; item < shopItemList.shopItems.Length; item++)
        {
            
            SetItemInformation(shopItemList.shopItems[item],item);
        }
    }

    //Sprite itemSprite, string itemName, int itemPrice, string itemType

    /// <summary>
    /// Create the shop items
    /// </summary>
    /// <param name="itemSprite"></param>
    /// <param name="itemName"></param>
    /// <param name="itemPrice"></param>
    /// <param name="index"></param>
    private void SetItemInformation(SOClothPart shopItem, int index)
    {

        Transform shopItemTransform = Instantiate(storeTemplate, storePanel);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        

        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * index);

        //Set the item information
        shopItemTransform.Find("ItemName").GetComponent<TextMeshProUGUI>().SetText(shopItem.itemName);
        shopItemTransform.Find("PriceText").GetComponent<TextMeshProUGUI>().SetText(shopItem.itemPrice.ToString());
        shopItemTransform.Find("ItemIcon").GetComponent<Image>().sprite = shopItem.itemSprite;


       Button button = shopItemTransform.GetComponent<Button>();
       button.onClick.AddListener(() => OnShopItemClicked(shopItem));



    }


    public void OnShopItemClicked(SOClothPart shopItem)
    {
        //Debug.Log("OnShopItemClicked: " + itemType);

        if (storeClient.HasCoinsToBuy(shopItem.itemPrice))
        {
            storeClient.ItemPurchased(shopItem);
        }
        else
        {
            
            messageText.text = "Not Enough Money";
            messagePanel.gameObject.SetActive(true);
        }
       
    }

   public void GetClientInfo(IStoreClient customer)
    {
        storeClient = customer;

        //Debug.Log("GetClientInfo: " + customer);

    }

    
    
}
