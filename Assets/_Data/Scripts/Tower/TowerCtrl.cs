using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : TungMonoBehaviour
{
    [SerializeField] protected TowerRadar radar;
    public TowerRadar Radar => radar;

    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    [SerializeField] protected TowerShooting towerShooting;
    public TowerShooting TowerShooting => towerShooting;

    [SerializeField] protected TowerLevel towerLevel;
    public TowerLevel TowerLevel => towerLevel;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRadar();
        this.LoadRotator();
        this.LoadTowerShooting();
        this.LoadTowerLevel();
    }
    protected virtual void LoadRadar()
    {
        if (this.radar != null) return;
        this.radar = GetComponentInChildren<TowerRadar>();
        Debug.Log(transform.name + " : LoadRadar ", gameObject);
    }
    protected virtual void LoadRotator()
    {
        if(this.rotator != null) return;
        this.rotator = transform.Find("Model").Find("Rotator");
        Debug.Log(transform.name + " : LoadRotator", gameObject);
    }
    protected virtual void LoadTowerShooting()
    {
        if (this.towerShooting != null) return;
        this.towerShooting = GetComponentInChildren<TowerShooting>();
        Debug.Log(transform.name + " : LoadTowerShooting ", gameObject);
    }
    protected virtual void LoadTowerLevel()
    {
        if (this.towerLevel != null) return;
        this.towerLevel = GetComponentInChildren<TowerLevel>();
        Debug.Log(transform.name + " : LoadTowerLevel", gameObject);
    }
}
