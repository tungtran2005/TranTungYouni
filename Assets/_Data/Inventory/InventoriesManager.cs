using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoriesManager : TungSingleton<InventoriesManager>
{
    [SerializeField] protected List<InventoryCtrl> inventories = new List<InventoryCtrl>();
    [SerializeField] protected List<ItemsProfileSO> itemProfiles = new List<ItemsProfileSO>();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
        this.LoadItemProfile();
    }
    protected virtual void LoadInventories()
    {
        if (this.inventories.Count > 0) return;
        foreach (Transform child in transform)
        {
            InventoryCtrl inventory = child.GetComponent<InventoryCtrl>();
            if (inventory == null) continue;
            this.inventories.Add(inventory);
        }
        Debug.Log(transform.name + " : LoadInventories", gameObject);
    }
    protected virtual void LoadItemProfile()
    {
        if (this.itemProfiles.Count > 0) return;
        ItemsProfileSO[] itemsProfileSOs = Resources.LoadAll<ItemsProfileSO>("/");
        this.itemProfiles = new List<ItemsProfileSO>(itemsProfileSOs);
        Debug.Log(transform.name + " : LoadItemProfile", gameObject);
    }
    public virtual InventoryCtrl Currency()
    {
        return this.GetByType(InventoryType.Currency);
    }

    public virtual InventoryCtrl Item()
    {
        return this.GetByType(InventoryType.Item);
    }
    protected virtual InventoryCtrl GetByType(InventoryType type)
    {
        foreach (InventoryCtrl inventory in this.inventories)
        {
            if (inventory.GetInventoryType() == type) return inventory;
        }
        return null;
    }
    protected virtual ItemsProfileSO GetProfileByCode(ItemCode type)
    {
        foreach (ItemsProfileSO itemsProfile in this.itemProfiles)
        {
            if (itemsProfile.itemType == type) return itemsProfile;
        }
        return null;
    }
    public virtual void AddItem(ItemInventory item)
    {
        InventoryType inventoryType = item.ItemProfile.inventoryType;
        InventoryCtrl inventory = this.GetByType(inventoryType);
        inventory.AddItem(item);
    }
    public virtual void AddItem(ItemCode itemType, int itemCount)
    {
        ItemsProfileSO itemsProfile = this.GetProfileByCode(itemType);
        ItemInventory item = new(itemsProfile, itemCount);
        this.AddItem(item);
    }
    public virtual void RemoveItem(ItemInventory item)
    {
        InventoryType inventoryType = item.ItemProfile.inventoryType;
        InventoryCtrl inventory = this.GetByType(inventoryType);
        inventory.RemoveItem(item);
    }
    public virtual void RemoveItem(ItemCode itemType, int itemCount)
    {
        ItemsProfileSO itemsProfile = this.GetProfileByCode(itemType);
        ItemInventory item = new(itemsProfile, itemCount);
        this.RemoveItem(item);
    } 
}
