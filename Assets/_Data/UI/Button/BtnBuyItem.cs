using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBuyItem : ButtonAbstract
{
    [SerializeField] protected ItemShop itemShop;
    [SerializeField] private InventoryCtrl inventory;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemShop();
    }
    protected virtual void LoadItemShop()
    {
        if (this.itemShop != null) return;
        this.itemShop = GetComponentInParent<ItemShop>();
        Debug.Log(transform.name + " : LoadItemShop", gameObject);
    }
    protected virtual bool CheckCanBuy()
    {
        this.inventory = InventoriesManager.Instance.Currency();
        if (this.inventory == null) return false;
        ItemInventory itemInventory = inventory.FindItem(ItemCode.Gold);
        if (itemInventory == null) return false;
        int CurrentGold = itemInventory.itemCount;
        return CurrentGold >= this.itemShop.Price;
    }
    protected override void OnClick()
    {
        this.BuyItem();
    }
    protected virtual void BuyItem()
    {
        if (!CheckCanBuy())
        {
            UIShop.Instance.Notification("khong du vang");
        }
        else
        {
            InventoriesManager.Instance.AddItem(this.itemShop.GetItemCode(), 1);
            InventoriesManager.Instance.RemoveItem(ItemCode.Gold, this.itemShop.Price);
            UIShop.Instance.Notification("Mua thanh cong");
        }
    }
}
