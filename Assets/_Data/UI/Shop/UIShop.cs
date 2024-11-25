using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIShop : TungSingleton<UIShop>
{
    [SerializeField] protected bool isShow = true;
    public bool IsShow => isShow;

    [SerializeField] protected Transform showHide;
    [SerializeField] protected TextMeshProUGUI notificationText;
    protected override void Start()
    {
        base.Start();
        this.Hide();
        this.HideNotification();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShowDide();
        this.LoadNotificationText();
    }
    protected virtual void LoadShowDide()
    {
        if (this.showHide != null) return;
        this.showHide = transform.Find("ShowHide");
        Debug.Log(transform.gameObject + " : LoadShowDide", gameObject);
    }
    protected virtual void LoadNotificationText()
    {
        if (this.notificationText != null) return;
        this.notificationText = GameObject.Find("TextNotification").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + " : LoadNotificationText", gameObject);
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
    protected virtual void HideNotification()
    {
        this.notificationText.gameObject.SetActive(false);
    }
    protected virtual void ShowNotification()
    {
        this.notificationText.gameObject.SetActive(true);
    }
    public virtual void Notification(string txt)
    {
        this.notificationText.text = txt;
        this.DisPlayNotification();
    }
    public virtual void DisPlayNotification()
    {
        this.ShowNotification();
        Invoke(nameof(HideNotification), 2f);
    }
}
