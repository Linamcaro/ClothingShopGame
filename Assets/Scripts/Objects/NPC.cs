using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IObjectClicked
{
    private bool isPlayerNear = false;

    public event EventHandler<ObjectClickedEventArgs> ShopKeeperInteraction;

    /// <summary>
    /// Check if the player is near and trigger the event
    /// </summary>
    public void OnMouseClick()
    {

        Debug.Log("NPC on Mouse Click called");

        if (isPlayerNear)
        {
            Debug.Log("isPlayerNear: " + isPlayerNear);

            ShopKeeperInteraction?.Invoke(this, new ObjectClickedEventArgs(gameObject.tag));

        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("OnCollision enter: " + collision.gameObject.tag);

            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("OnCollision exit: " + collision.gameObject.tag);
            isPlayerNear = false;
        }
    }



}

public class ObjectClickedEventArgs : EventArgs
{
    public string objectTag;

    public ObjectClickedEventArgs(string tag)
    {
        objectTag = tag;
    }
}
