using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop Items", menuName = "Cloth Item")]
public class SOClothPart : ScriptableObject
{
    public string itemName;
    public string itemType;
    public int itemPrice;
    public Sprite itemSprite;
}
