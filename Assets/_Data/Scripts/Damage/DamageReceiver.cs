using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : EnemyAbstract
{
    [SerializeField] protected int currentHP = 6;
    public int CurrentHP => currentHP;
    [SerializeField] protected int maxHP = 6;
    public int MaxHP => maxHP;
    [SerializeField] protected bool isDead = false;

    public virtual void Deduct(int damage)
    {
        this.currentHP -= damage;
        if (this.IsDead()) this.OnDead();
    }
    public virtual bool IsDead()
    {
        return this.isDead = this.currentHP <= 0;
    }
    protected virtual void Reborn()
    {
        this.currentHP = this.maxHP;
        this.isDead = false;
    }
    public virtual void OnDead()
    {
        if (!this.IsDead()) return;
        //For override
    }
}
