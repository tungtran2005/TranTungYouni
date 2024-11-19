using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : TungMonoBehaviour
{
    [SerializeField] protected Transform content;
    [SerializeField] protected InventoryCtrl inventoryCtrl;
    [SerializeField] protected UIItem UIItemPrefab;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ShowItem();
    }
    protected virtual void ShowItem()
    {
        this.ClearItem();
        UIItem uIItem;
        foreach (ItemInventory item in this.inventoryCtrl.Items)
        {
            uIItem = this.CreateItem(item);
            uIItem.transform.SetParent(this.content);
        }
    }
    protected virtual void ClearItem()
    {
        foreach (Transform child in this.content)
        {
            Destroy(child.gameObject);
        }
    }
    protected virtual UIItem CreateItem(ItemInventory item)
    {
        UIItem uIItem = Instantiate(this.UIItemPrefab);
        uIItem.SetUIItem(item);
        return uIItem;
    }
    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Viewport").Find("Content");
        Debug.Log(transform.name + " : LoadContent", gameObject);
    }
}
