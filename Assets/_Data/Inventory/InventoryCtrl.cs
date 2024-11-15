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
        ItemInventory itemExist = this.FindItem(item.ItemProfile.itemType);
        if (!item.ItemProfile.isStackable || itemExist == null)
        {
            item.SetId(Random.Range(0, 9999999));
            this.Items.Add(item);
            return;
        }
        itemExist.itemCount += item.itemCount;
    }
    public virtual bool RemoveItem(ItemInventory item)
    {
        ItemInventory itemExist = this.FindItemNotEmpty(item.ItemProfile.itemType);
        if (itemExist == null) return false;
        itemExist.Deduct(item.itemCount);
        if (itemExist.itemCount == 0) this.items.Remove(item);
        return true;
    }
    public virtual ItemInventory FindItem(ItemType itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.ItemProfile.itemType == itemCode) return itemInventory;
        }

        return null;
    }

    public virtual ItemInventory FindItemNotEmpty(ItemType itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.ItemProfile.itemType != itemCode) continue;
            if (itemInventory.itemCount > 0) return itemInventory;
        }

        return null;
    }
}
