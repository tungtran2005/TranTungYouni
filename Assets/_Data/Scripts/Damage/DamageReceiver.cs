using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : EnemyAbstract
{
    [SerializeField] protected int cunrrentHP = 6;
    [SerializeField] protected int HPMax = 6;
    [SerializeField] protected bool isDead = false;

    public virtual void Deduct(int damage)
    {
        this.cunrrentHP -= damage;
        if (this.IsDead()) this.OnDead();
    }
    public virtual bool IsDead()
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
        if (!this.IsDead()) return;
        //For override
    }
}
