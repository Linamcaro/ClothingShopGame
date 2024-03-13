using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteractionUI : MonoBehaviour
{

    [SerializeField] GameObject shopKeeperPanel;
    [SerializeField] GameObject clothStorePanel;


    // Start is called before the first frame update
    void Start()
    {
        ///Suscribe to all the objects that have the ObjectInteraction component attached
        ObjectInteraction[] eventObjects = FindObjectsOfType<ObjectInteraction>();

        foreach (ObjectInteraction objectInteraction  in eventObjects)
        {
            objectInteraction.OnObjectInteraction += OnObjectInteraction;
        }

        DisableGameObject(shopKeeperPanel);
        DisableGameObject(clothStorePanel);
    }

    private void OnObjectInteraction(object sender, ObjectClickedEventArgs args)
    {
        if(args.objectTag == "ShopKeeper")
        {
            EnableGameObject(shopKeeperPanel);
            

        }else if(args.objectTag == "ClothStand")
        {
            EnableGameObject(clothStorePanel);
        }
    }


    public void EnableGameObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
        PlayerControls.Instance.OnDisable();
    }

    public void DisableGameObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
        PlayerControls.Instance.OnEnable();
    }

}
