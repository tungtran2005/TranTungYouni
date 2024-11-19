using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextExpCount : TextAbstract
{
    private void FixedUpdate()
    {
        this.LoadExpCount();
    }
    protected virtual void LoadExpCount()
    {
        ItemInventory item = InventoriesManager.Instance.Currency().FindItem(ItemCode.PlayerExp);
        string itemCount;
        if (item == null) itemCount = "0";
        else itemCount = item.itemCount.ToString();
        this.textPro.text = itemCount;
    }
}
