using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSilverCount : TextAbstract
{
    private void FixedUpdate()
    {
        this.LoadSilverCount();
    }
    protected virtual void LoadSilverCount()
    {
        ItemInventory item = InventoriesManager.Instance.Currency().FindItem(ItemType.Silver);
        string itemCount;
        if (item == null) itemCount = "0";
        else itemCount = item.itemCount.ToString();
        this.textPro.text = itemCount;
    }
}
