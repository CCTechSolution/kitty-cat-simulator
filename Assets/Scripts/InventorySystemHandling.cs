/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventorySystemHandling : MonoBehaviour
{
    public static InventorySystemHandling instance;
    public Item[] items;
    private int currentItemIndex = 0;

    private void Awake()
    {
        instance = this;
    }
    public void AddInventory()
    {
        if (PlayerManager.instance.PrevPickable != null)
        {
            foreach (var Item in items)
            {
                if (Item.itemName == PlayerManager.instance.PrevPickable.name)
                {
                    Item.gameObject.SetActive(true);
                    break;
                }
            }
        }

    }
    public void SwicthItem(GameObject item)
    {
        if (PlayerManager.instance.currentPickable != null)
        {
            PlayerManager.instance.currentPickable.SetActive(false);
            item.SetActive(true);
            PlayerManager.instance.currentPickable = item;

        }
        if (PlayerManager.instance.currentPickable == null)
        {
            item.SetActive(true);

        }

    }

 
}

*/