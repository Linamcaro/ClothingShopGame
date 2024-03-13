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

        NPC[] npcs = FindObjectsOfType<NPC>();

        foreach (NPC npc in npcs)
        {
            npc.ShopKeeperInteraction += OnObjectInteraction;
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
