using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class TextAbstract : TungMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textPro;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextpro();
    }
    protected virtual void LoadTextpro()
    {
        if (this.textPro != null) return;
        this.textPro = GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + " : LoadTextpro", gameObject);
    }
}
