using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornEnemy : TungMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemy;
    [SerializeField] protected Transform holderPrefab;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 4f;
    [SerializeField] protected int pointIndex = 0;
    [SerializeField] protected List<BornPoint> bornPoints = new List<BornPoint>();

    private void FixedUpdate()
    {
        this.CreateEnemy();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolder();
        this.LoadBornPoint();
    }
    protected virtual void CreateEnemy()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;
        BornPoint bornPoint = this.GetBornPoint();
        this.enemy = EnemySpawnerCtrl.Instance.Prefabs.GetRandom();
        EnemyCtrl newEnemy = EnemySpawnerCtrl.Instance.Spawner.Spawn(this.enemy, bornPoint.transform.position);
        newEnemy.gameObject.SetActive(true);
        newEnemy.transform.parent = this.holderPrefab;
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
    protected virtual void LoadHolder()
    {
        if (this.holderPrefab != null) return;
        this.holderPrefab = GameObject.Find("Holder").transform;
        Debug.Log(transform.name + " : LoadHolder ", gameObject);
    }
}
