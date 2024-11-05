using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class InventoryCtrl : MonoBehaviour
{
    [SerializeField] protected List<ItemInventory> items = new List<ItemInventory>();
    public List<ItemInventory> Items => items;

    public abstract InventoryType GetInventoryType();
    public virtual void AddItem(ItemInventory item)
    {
        ItemInventory itemExist = this.FindItem(item);
        if (itemExist == null)
        {
            item.SetId(Random.Range(0, 9999999));
            this.Items.Add(item);
            return;
        }
        itemExist.itemCount += item.itemCount;
    }
    protected virtual ItemInventory FindItem(ItemInventory item)
    {
        foreach (ItemInventory itemInventory in items)
        {
            if (itemInventory.ItemProfile.itemType != item.ItemProfile.itemType) continue;
            if (itemInventory.CanAdd(item.itemCount)) return itemInventory;
        }
        return null;
    }
    public virtual bool RemoveItem(ItemInventory item)
    {
        ItemInventory itemExist = this.FindItemNotEmpty(item);
        if (itemExist == null) return false;
        itemExist.Deduct(item.itemCount);
        if (itemExist.itemCount == 0) this.items.Remove(item);
        return true;
    }
    protected virtual ItemInventory FindItemNotEmpty(ItemInventory item)
    {
        foreach (ItemInventory itemInventory in items)
        {
            if (itemInventory.ItemProfile.itemType != item.ItemProfile.itemType) continue;
            if (itemInventory.CanDeduct(item.itemCount)) return itemInventory;
        }
        return null;
    }
}
