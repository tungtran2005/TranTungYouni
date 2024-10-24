using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public abstract class DamageSender : TungMonoBehaviour
{
    [SerializeField] protected int damge = 1;
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected Collider _collider;
    protected virtual void OnTriggerEnter(Collider other)
    {
        DamageReceiver damageReceiver = other.GetComponent<DamageReceiver>();
        if (damageReceiver == null)
        {
            Debug.Log("ontrigger" + other.name);
            return;
        }
        damageReceiver.Deduct(this.damge);
        //Debug.Log(transform.name + " damage " + other.name);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadCollider();
    }
    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody>();
        this.rb.useGravity = false;
        Debug.Log(transform.name + " : LoadRigidbody", gameObject);
    }
    protected virtual void LoadCollider()
    {
        if(this._collider != null) return;  
        this._collider = GetComponent<Collider>();
        this._collider.isTrigger = true;
        Debug.Log(transform.name + " : LoadCollider ", gameObject );
    }
}
