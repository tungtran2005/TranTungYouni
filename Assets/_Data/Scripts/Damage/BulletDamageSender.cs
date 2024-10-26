using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected BulletDespawn despawn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.parent.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + " : LoadDespawn", gameObject);
    }
    protected override void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<Collider>();
        this._collider.isTrigger = true;
        this.sphereCollider = (SphereCollider)this._collider;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + " : LoadCollider ", gameObject);
    }
    protected override DamageReceiver SenderDamage(Collider other)
    {
        DamageReceiver damageReceiver = base.SenderDamage(other);
        if(damageReceiver == null) return null;
        this.despawn.DoDespawn();
        return damageReceiver;
    }
}
