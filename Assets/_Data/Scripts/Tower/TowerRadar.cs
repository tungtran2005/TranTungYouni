using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class TowerRadar : TungMonoBehaviour
{
    [SerializeField] protected EnemyCtrl nearest;
    [SerializeField] protected SphereCollider _sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected List<EnemyCtrl> enemies = new List<EnemyCtrl>();
    
    protected void OnTriggerEnter(Collider collider)
    {
        DamageReceiver enemy = collider.GetComponent<DamageReceiver>();
        if (enemy == null) return;
        EnemyCtrl enemyCtrl = collider.GetComponentInParent<EnemyCtrl>();
        this.AddEnemy(enemyCtrl);
    }
    protected void OnTriggerExit(Collider collider)
    {
        DamageReceiver enemy = collider.GetComponent<DamageReceiver>();
        if (enemy == null) return;
        EnemyCtrl enemyCtrl = collider.GetComponentInParent<EnemyCtrl>();
        this.RemoveEnemy(enemyCtrl);
    }
    private void FixedUpdate()
    {
        this.FindEnemyNearest();
        this.CheckIsDead();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadSphereCollider()
    {
        if(this._sphereCollider != null) return;
        this._sphereCollider = GetComponent<SphereCollider>();
        
        this._sphereCollider.isTrigger = true;
        this._sphereCollider.radius = 15;
        Debug.Log(transform.name + " : LoadSphereCollider ", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if(this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        
        this._rigidbody.useGravity = false;
        Debug.Log(transform.name + " : LoadRigidbody ", gameObject);
    }
    protected virtual void FindEnemyNearest()
    {
        float DistanceMin = Mathf.Infinity;
        foreach (EnemyCtrl enemy in enemies)
        {
            float currentDistance = Vector3.Distance(enemy.transform.position, transform.position);
            if(DistanceMin > currentDistance)
            {
                DistanceMin = currentDistance;
                nearest = enemy;
            }
        }
    }
    protected virtual void AddEnemy(EnemyCtrl enemy)
    {
        this.enemies.Add (enemy);
    }
    protected virtual void RemoveEnemy(EnemyCtrl enemy)
    {
        if(this.nearest == enemy) this.nearest = null;
        this.enemies.Remove (enemy);
    }
    public virtual EnemyCtrl GetTarget()
    {
        return this.nearest;
    }
    protected virtual void CheckIsDead()
    {
        if(this.nearest == null) return;
        if (this.nearest.DamageReceiver.IsDaed())
        {
            this.RemoveEnemy(this.nearest);
        }
    }
}
