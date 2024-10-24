using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : TungMonoBehaviour
{
    [SerializeField] protected int cunrrentHP = 10;
    [SerializeField] protected int HPMax = 10;
    [SerializeField] protected bool isDead = false;

    public virtual void Deduct(int damage)
    {
        if(this.IsDaed()) return;
        this.cunrrentHP -= damage;
    }
    protected virtual bool IsDaed()
    {
        return this.isDead = this.cunrrentHP <= 0;
    }
}
