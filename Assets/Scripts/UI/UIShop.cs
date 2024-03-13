using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

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

    void Start()
    {
        
    }

    
}
