using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : EnemyAbstract
{
    [SerializeField] protected int cunrrentHP = 6;
    [SerializeField] protected int HPMax = 6;
    [SerializeField] protected bool isDead = false;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    public virtual void Deduct(int damage)
    {
        this.cunrrentHP -= damage;
        if (this.IsDaed()) this.OnDead();
    }
    public virtual bool IsDaed()
    {
        return this.isDead = this.cunrrentHP <= 0;
    }
    protected virtual void Reborn()
    {
        this.cunrrentHP = this.HPMax;
        this.isDead = false;
    }
    public virtual void OnDead()
    {
        if (!this.IsDaed()) return;
        //For override
    }
}
