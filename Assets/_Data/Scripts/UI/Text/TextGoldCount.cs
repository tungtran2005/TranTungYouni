using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGoldCount : TextAbstract
{
    private void FixedUpdate()
    {
        this.LoadGoldCount();
    }
    protected virtual void LoadGoldCount()
    {
        ItemInventory item = InventoriesManager.Instance.Currency().FindItem(ItemType.Gold);
        string itemCount;
        if (item == null) itemCount = "0";
        else itemCount = item.itemCount.ToString();
        this.textPro.text = itemCount;
        
    }
}
