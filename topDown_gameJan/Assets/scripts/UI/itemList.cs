using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemShop", menuName = "Shop/ItemShop")]
public class itemList : ScriptableObject
{
    public enum ItemType
    {
        armor,
        hat,
        glass,
        eyes,
        groves
    };

    public string itemName;
    public string id;
    public ItemType itemtype;
    public Sprite figure;
    public float price;
   
}
