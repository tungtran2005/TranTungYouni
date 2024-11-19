using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : TowerAbstract
{
    [SerializeField] protected string effecName = "Spear";
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 10f;
    [SerializeField] protected FirePointHeavy firePoint;
    private void FixedUpdate()
    {
        this.Attack();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFirePoint();
    }
    protected virtual void LoadFirePoint()
    {
        if (this.firePoint != null) return;
        this.firePoint = transform.parent.GetComponentInChildren<FirePointHeavy>();
        Debug.LogWarning(transform.name + ": LoadFirePoint", gameObject);
    }
    protected virtual void Attack()
    {
        if (this.ctrl.TowerShooting.Target == null) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;
        Vector3 pos = this.firePoint.transform.position;
        Quaternion ros = this.firePoint.transform.rotation;
        EffecCtrl prefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(this.effecName);
        EffecCtrl newPrefab = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, pos, ros);
        newPrefab.gameObject.SetActive(true);
    }
}
