using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornEnemy : TungMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemy;
    [SerializeField] protected Transform holderPrefab;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 4f;

    private void FixedUpdate()
    {
        this.CreateEnemy();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolder();
    }
    protected virtual void CreateEnemy()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;
        EnemyCtrl newEnemy = EnemySpawnerCtrl.Instance.Spawner.Spawn(this.enemy, transform.parent.position);
        newEnemy.gameObject.SetActive(true);
        newEnemy.transform.parent = this.holderPrefab;
    }

    protected virtual void LoadHolder()
    {
        if (this.holderPrefab != null) return;
        this.holderPrefab = GameObject.Find("Holder").transform;
        Debug.Log(transform.name + " : LoadHolder ", gameObject);
    }
}
