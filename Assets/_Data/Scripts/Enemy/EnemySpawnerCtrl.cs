using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : TungSingleton<EnemySpawnerCtrl>
{
    [SerializeField] protected EnemySpawner spawner;
    public EnemySpawner Spawner => spawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<EnemySpawner>();
        Debug.Log(transform.name + " : LoadSpawner", gameObject);
    }
}
