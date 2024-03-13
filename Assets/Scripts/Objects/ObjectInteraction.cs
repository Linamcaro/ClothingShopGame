using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour, IObjectClicked
{
    private bool isPlayerNear = false;

    public event EventHandler<ObjectClickedEventArgs> OnObjectInteraction;

    private IStoreClient playerInfo;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("OnCollision enter: " + collision.gameObject.tag);
            isPlayerNear = true;
            playerInfo = collision.GetComponent<IStoreClient>();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("OnCollision exit: " + collision.gameObject.tag);
            isPlayerNear = false;
        }
    }


    /// <summary>
    /// Check if the player is near and trigger the event
    /// </summary>
    public void OnMouseClick()
    {

        //Debug.Log("NPC on Mouse Click called");

        if (isPlayerNear)
        {
            //Debug.Log("isPlayerNear: " + isPlayerNear);

            OnObjectInteraction?.Invoke(this, new ObjectClickedEventArgs(gameObject.tag, playerInfo));

        }
    }



}

public class ObjectClickedEventArgs : EventArgs
{
    public string objectTag;
    public IStoreClient playerInfo;

    public ObjectClickedEventArgs(string tag, IStoreClient info)
    {
        objectTag = tag;
        playerInfo = info;
    }
}
