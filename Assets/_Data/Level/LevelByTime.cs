using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByTime : LevelAbstract
{
    [SerializeField] protected float timer = 0;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Timing();

    }
    protected virtual void Timing()
    {
        this.timer += Time.fixedDeltaTime;
    }
    protected override bool DeductExp(int exp)
    {
        return this.DeductTime(exp);
    }
    protected virtual bool DeductTime(int num)
    {
        if (this.timer < num) return false;
        this.timer -= num;
        return true;
    }
    protected override int GetCurrentExp()
    {
        return (int)this.timer;
    }
}
