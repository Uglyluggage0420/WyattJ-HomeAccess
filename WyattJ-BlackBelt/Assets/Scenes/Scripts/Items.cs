using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item")]
public class Items : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public float healAmount;
    public ItemType itemType;
    public enum ItemType
    {
        SmallHeal,
        BigHeal,
        Armor
    }
}
