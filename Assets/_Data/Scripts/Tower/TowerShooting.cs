using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [Header("shooting")]
    [SerializeField] protected EnemyCtrl target;
    public EnemyCtrl Target => target;
    [SerializeField] protected string effecName = "Bullet";
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 1f;
    [SerializeField] protected int pointIndex = 0;
    [SerializeField] protected List<FirePoint> firePoints = new List<FirePoint>();
    [SerializeField] protected int killCount = 0;
    public int KillCount => killCount;
    [SerializeField] protected int totalKill = 0;
    protected virtual void Update()
    {
        this.GetTarget();
        this.LookAtTarget();
        this.Shooting();
        this.IsTargetDead();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFirePoint();
    }
    protected virtual void GetTarget()
    {
        this.target = this.ctrl.Radar.GetTarget();
    }
    protected virtual void LookAtTarget()
    {
        if(this.target == null) return;
        this.ctrl.Rotator.LookAt(this.target.EnemyDamageReceiver.transform.position);
    }
    protected virtual void Shooting()
    {
        if(this.target == null) return;
        this.timer += Time.deltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;
        FirePoint firePoint = this.GetFirePoint();
        EffecCtrl prefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(this.effecName);
        EffecCtrl newEffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, firePoint.transform.position, firePoint.transform.rotation);
        newEffect.gameObject.SetActive(true);
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
    protected virtual bool IsTargetDead()
    {
        if (this.target == null) return true;
        if (!this.target.EnemyDamageReceiver.IsDead()) return false;
        if (this.target.EnemyDamageReceiver.IsAlreadyCounted) return false;
        this.target.EnemyDamageReceiver.IsAlreadyCounted = true;
        this.killCount++;
        this.totalKill++;
        this.target = null;
        return true;
    }

    public virtual bool DeductKillCount(int count)
    {
        if (this.killCount < count) return false;
        this.killCount -= count;
        return true;
    }
    }
