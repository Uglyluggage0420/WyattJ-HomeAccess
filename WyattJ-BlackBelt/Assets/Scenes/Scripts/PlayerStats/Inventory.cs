using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{

    public Image[] itemSlots;
    public Items[] invItemInfo;

    public void AddItem(Items itemInfo)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].sprite == null)
            {
                invItemInfo[i] = itemInfo;
                itemSlots[i].sprite = itemInfo.itemIcon;
                break;
            }
        }
    }
}
