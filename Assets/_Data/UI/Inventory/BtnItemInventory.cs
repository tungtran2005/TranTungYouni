using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnItemInventory : ButtonAbstract
{
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    [SerializeField] protected TextMeshProUGUI textName;
    [SerializeField] protected TextMeshProUGUI textNumber;
    [SerializeField] protected Image image;

    private void FixedUpdate()
    {
        this.ItemUpdate();
    }
    protected override void LoadButton()
    {
        base.LoadButton();
        this.LoadTextName();
        this.LoadTextNumber();
        this.LoadImage();
    }
    protected virtual void LoadTextName()
    {
        if (this.textName != null) return;
        this.textName = transform.Find("TextName").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + " : LoadTextName ", gameObject);
    }
    protected virtual void LoadTextNumber()
    {
        if (this.textNumber != null) return;
        this.textNumber = transform.Find("TextNumber").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + " : LoadTextNumber ", gameObject);
    }
    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = transform.Find("Image").GetComponent<Image>();
        Debug.Log(transform.name + " : LoadImage ", gameObject);
    }
    protected override void OnClick()
    {
        //ToDo
    }
    public virtual void SetItem(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }
    protected virtual void ItemUpdate()
    {
        this.textNumber.text = this.itemInventory.itemCount.ToString();
        this.textName.text = this.itemInventory.GetName();
        this.image.sprite = this.itemInventory.ItemProfile.sprite;
        if (this.itemInventory.itemCount == 0) Destroy(gameObject); 
    }
}
