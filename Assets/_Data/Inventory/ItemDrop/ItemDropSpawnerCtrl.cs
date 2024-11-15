using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawnerCtrl : TungSingleton<ItemDropSpawnerCtrl>
{
    [SerializeField] protected ItemDropSpawner spawner;
    public ItemDropSpawner Spawner => spawner;

    [SerializeField] protected ItemDropPrefabs prefabs;
    public ItemDropPrefabs Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadItemDropPrefabs();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<ItemDropSpawner>();
        Debug.Log(transform.name + " : LoadSpawner", gameObject);
    }
    protected virtual void LoadItemDropPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponentInChildren<ItemDropPrefabs>();
        Debug.Log(transform.name + " : LoadItemDropPrefabs", gameObject);
    }
    public virtual ItemDropCtrl Drop(ItemType itemCode, Vector3 position, int dropCount)
    {
        ItemDropCtrl prefab = this.Prefabs.GetByName(itemCode.ToString());
        ItemDropCtrl newObject = this.Spawner.Spawn(prefab, position);
        newObject.SetDropCount(dropCount);
        newObject.gameObject.SetActive(true);
        return newObject;
    }

    public virtual void DropMany(ItemType itemCode, Vector3 dropPosition, int dropCount)
    {
        for (int i = 0; i < dropCount; i++)
        {
            this.Drop(itemCode, dropPosition, 1);
        }
    }
}
