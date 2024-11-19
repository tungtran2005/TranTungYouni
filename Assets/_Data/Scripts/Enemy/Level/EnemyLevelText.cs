using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelText : TextLevel
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + " : LoadEnemyCtrl", gameObject);
    }
    protected override string GetLevel()
    {
        return this.enemyCtrl.EnemyLevelByTime.CurrentLevel.ToString();
    }
}
