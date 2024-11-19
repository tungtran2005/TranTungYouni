using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLevelText : TextLevel
{
    [SerializeField] protected TowerCtrl towerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }
    protected virtual void LoadTowerCtrl()
    {
        if (this.towerCtrl != null) return;
        this.towerCtrl = GetComponentInParent<TowerCtrl>();
        Debug.Log(transform.name + "  : LoadTowerCtrl", gameObject);
    }
    protected override string GetLevel()
    {
        return this.towerCtrl.TowerLevel.CurrentLevel.ToString();
    }
}
