using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected EnemyCtrl target;
    [SerializeField] protected EffecCtrl bullet;
    [SerializeField] protected Transform holderPrefab;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 1f;
    [SerializeField] protected int pointIndex = 0;
    [SerializeField] protected List<FirePoint> firePoints = new List<FirePoint>();
    protected virtual void FixedUpdate()
    {
        this.GetTarget();
        this.LookAtTarget();
        this.Shooting();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFirePoint();
        this.LoadHolder();
    }
    protected virtual void GetTarget()
    {
        this.target = this.ctrl.Radar.GetTarget();
    }
    protected virtual void LookAtTarget()
    {
        if(this.target == null) return;
        this.ctrl.Rotator.LookAt(this.target.transform);
    }
    protected virtual void Shooting()
    {
        if(this.target == null) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;
        FirePoint firePoint = this.GetFirePoint();
        EffecCtrl newEffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(this.bullet, firePoint.transform.position, firePoint.transform.rotation);
        newEffect.gameObject.SetActive(true);
        newEffect.transform.parent = this.holderPrefab;
    }
    protected virtual FirePoint GetFirePoint()
    {
        this.pointIndex++;
        if(this.pointIndex >= this.firePoints.Count) this.pointIndex = 0;
        return this.firePoints[this.pointIndex];
    }
    protected virtual void LoadFirePoint()
    {
        if(this.firePoints.Count > 0) return;
        FirePoint[] points = this.ctrl.GetComponentsInChildren<FirePoint>();
        this.firePoints = new List<FirePoint>(points);
        Debug.LogWarning (transform.name + ": LoadFirePoint", gameObject);
    }
    protected virtual void LoadHolder()
    {
        if (this.holderPrefab != null) return;
        this.holderPrefab = GameObject.Find("Holder").transform;
        Debug.Log(transform.name + " : LoadHolder ", gameObject);
    }
}
