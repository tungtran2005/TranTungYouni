using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ItemShop : TungMonoBehaviour
{
    [SerializeField] protected int price;
    public int Price => price;
    [SerializeField] protected TextMeshProUGUI textPrice;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextPrice();
        this.SetPrice();
        this.UpdateText();
        
    }
    protected virtual void LoadTextPrice()
    {
        if (this.textPrice != null) return;
        this.textPrice = transform.Find("TextPrice").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + " : LoadTextPrice", gameObject);
    }
    protected virtual void UpdateText()
    {
        this.textPrice.text = this.price.ToString() + " G";
    }
    public abstract ItemCode GetItemCode();
    public abstract int SetPrice();

}
