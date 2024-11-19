using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornEnemy : TungMonoBehaviour
{
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 4f;
    [SerializeField] protected int pointIndex = 0;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<BornPoint> bornPoints = new List<BornPoint>();
    [SerializeField] protected List<EnemyCtrl> spawnedEnemies = new List<EnemyCtrl>();
    

    private void FixedUpdate()
    {
        this.CreateEnemy();
        this.RemoveOnDead();
    }
    protected virtual void RemoveOnDead()
    {
        foreach(EnemyCtrl enemyCtrl in this.spawnedEnemies)
        {
            if (enemyCtrl.EnemyDamageReceiver.IsDead())
            {
                this.spawnedEnemies.Remove(enemyCtrl);
                return;
            }
        }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBornPoint();
        
    }
    protected virtual void CreateEnemy()
    {
        if (this.spawnedEnemies.Count >= this.maxSpawn) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;
        BornPoint bornPoint = this.GetBornPoint();
        EnemyCtrl prefab = EnemySpawnerCtrl.Instance.Prefabs.GetRandom();
        EnemyCtrl newEnemy = EnemySpawnerCtrl.Instance.Spawner.Spawn(prefab, bornPoint.transform.position);
        newEnemy.gameObject.SetActive(true);
        this.spawnedEnemies.Add(newEnemy);
    }
    protected virtual BornPoint GetBornPoint()
    {
        this.pointIndex++;
        if (this.pointIndex >= this.bornPoints.Count) this.pointIndex = 0;
        return this.bornPoints[this.pointIndex];
    }
    protected virtual void LoadBornPoint()
    {
        if (this.bornPoints.Count > 0) return;
        BornPoint[] points = GetComponentsInChildren<BornPoint>();
        this.bornPoints = new List<BornPoint>(points);
        Debug.Log(transform.name + " : LoadBornPoint", gameObject);
    }
}
