using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    private Transform storePanel;
    private Transform storeTemplate;

    private void Awake()
    {
        
        storePanel = transform.Find("StorePanel");
        storeTemplate = storePanel.Find("StoreTemplate");
        
        storePanel.gameObject.SetActive(false);

    }

    private void Start()
    {
        
    }


    /// <summary>
    /// Create the shop items
    /// </summary>
    /// <param name="itemSprite"></param>
    /// <param name="itemName"></param>
    /// <param name="itemPrice"></param>
    /// <param name="index"></param>
    private void CreateItemButton(Sprite itemSprite, string itemName, int itemPrice, int index)
    {

        Transform shopItemTransform = Instantiate(storeTemplate, storePanel);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        //Set the position
        float shopItemHeight = 20f;
        shopItemRectTransform.anchoredPosition = new Vector2(0,-shopItemHeight * index);

        //Set the item information
        shopItemTransform.Find("ItemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("PriceText").GetComponent<TextMeshProUGUI>().SetText(itemPrice.ToString());
        shopItemTransform.Find("ItemIcon").GetComponent<Image>().sprite = itemSprite;



    }
    
}
