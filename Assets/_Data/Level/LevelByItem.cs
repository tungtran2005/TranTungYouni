using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelByItem : LevelAbstract
{
    [SerializeField] protected ItemInventory itemInventory;

    protected abstract ItemCode GetItemCode();
    protected override bool DeductExp(int exp)
    {
        return this.GetItemInventory().Deduct(exp);
    }

    protected override int GetCurrentExp()
    {
        if (this.GetItemInventory() == null) return 0;
        return this.itemInventory.itemCount;
    }
    protected virtual ItemInventory GetItemInventory()
    {
        if (this.itemInventory == null || this.itemInventory.ItemID == 0)
        {
            this.itemInventory = InventoriesManager.Instance.Currency().FindItem(this.GetItemCode());
        } 
        return this.itemInventory;
    }
}
