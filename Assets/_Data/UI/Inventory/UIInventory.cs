using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : TungSingleton<UIInventory>
{
    [SerializeField] protected bool isShow = true;
    public bool IsShow => isShow;

    [SerializeField] protected Transform showHide;
    [SerializeField] protected BtnItemInventory defaultItemInventoryUI;
    [SerializeField] protected List<BtnItemInventory> btnItems;

    private void FixedUpdate()
    {
        this.ItemsUpdating();
    }
    private void LateUpdate()
    {
        this.HotKeyToggle();
    }
    protected override void Start()
    {
        base.Start();
        this.HideDefaultItemInventory();
        this.Hide();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShowDide();
        this.LoadBtnItemInventory();
    }
    protected virtual void LoadShowDide()
    {
        if (this.showHide != null) return;
        this.showHide = transform.Find("ShowHide");
        Debug.Log(transform.gameObject + " : LoadShowDide", gameObject);
    }
    protected virtual void LoadBtnItemInventory()
    {
        if (this.defaultItemInventoryUI != null) return;
        this.defaultItemInventoryUI = GetComponentInChildren<BtnItemInventory>();
        Debug.Log(transform.name + " : LoadBtnItemInventory", gameObject);
    }
    public virtual void Show()
    {
        this.showHide.gameObject.SetActive(true);
        this.isShow = true;
    }
    public virtual void Hide()
    {
        this.showHide.gameObject.SetActive(false);
        this.isShow = false;
    }
    public virtual void Toggle()
    {
        if (this.isShow) this.Hide();
        else this.Show();
    }
    protected virtual void HideDefaultItemInventory()
    {
        this.defaultItemInventoryUI.gameObject.SetActive(false);
    }
    protected virtual void ItemsUpdating()
    {
        if (!this.isShow) return;
        InventoryCtrl itemInvCtrl = InventoriesManager.Instance.Item();

        BtnItemInventory newBtnItem;
        foreach (ItemInventory itemInventory in itemInvCtrl.Items)
        {
            newBtnItem = this.GetExistItem(itemInventory);
            if (newBtnItem == null)
            {
                newBtnItem = Instantiate(this.defaultItemInventoryUI);
                newBtnItem.transform.SetParent(this.defaultItemInventoryUI.transform.parent);
                newBtnItem.SetItem(itemInventory);
                newBtnItem.transform.localScale = new Vector3(1, 1, 1);
                newBtnItem.gameObject.SetActive(true);
                newBtnItem.name = itemInventory.GetName() + "-" + itemInventory.ItemID;
                this.btnItems.Add(newBtnItem);
            }
        }
    }
    protected virtual BtnItemInventory GetExistItem(ItemInventory itemInventory)
    {
        foreach (BtnItemInventory btnItem in this.btnItems)
        {
            if (btnItem.ItemInventory.ItemID == itemInventory.ItemID) return btnItem;
        }
        return null;
    }
    protected virtual void HotKeyToggle()
    {
        if(Input.GetKeyUp(KeyCode.I)) this.Toggle();
    }
}
