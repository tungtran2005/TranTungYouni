using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIItem : TungMonoBehaviour
{   [SerializeField] protected TextMeshProUGUI textNumber;
    [SerializeField] protected TextMeshProUGUI textName;
    [SerializeField] protected ItemInventory item;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextNumber();
        this.LoadTextName();
    }
    protected virtual void LoadTextNumber()
    {
        if (this.textNumber != null) return;
        this.textNumber = transform.Find("TextNumber").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + " : LoadTextPro", gameObject);
    }
    protected virtual void LoadTextName()
    {
        if (this.textName != null) return;
        this.textName = transform.Find("TextName").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + " : LoadTextName", gameObject);
    }
    public virtual void SetUIItem(ItemInventory item)
    {
        this.item = item;
        this.textNumber.text = item.GetName();
        this.textName.text = item.itemCount.ToString();
    }
}
