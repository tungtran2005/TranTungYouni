using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : TungMonoBehaviour where T : PoolObj
{
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected List<T> inPoolObj = new();
    public virtual T Spawn(T prefab)
    {
        T newObject = this.GetObjInPool(prefab);
        if (newObject == null)
        {
            newObject = Instantiate(prefab);
            this.spawnCount++;
            this.UpdateName(prefab.transform, newObject.transform);
        }
        return newObject;
    }
    public virtual T Spawn(T prefab, Vector3 pos)
    {
        T newObject = this.Spawn(prefab);
        newObject.transform.position = pos;
        return newObject;
    }
    public virtual T Spawn(T prefab, Vector3 pos, Quaternion ros)
    {
        T newObject = this.Spawn(prefab, pos);
        newObject.transform.rotation = ros;
        return newObject;
    }
    protected virtual T GetObjInPool(T prefab)
    {
        foreach (T obj in inPoolObj)
        {
            if(obj.GetName() == prefab.GetName())
            {
                this.RemoveObjInPool(obj);
                return obj;
            }
        }
        return null;
    }
    protected virtual void UpdateName(Transform prefab, Transform newObject)
    {
        newObject.name = prefab.name + "_" + spawnCount; 
    }
    protected virtual void RemoveObjInPool(T prefab)
    {
        this.inPoolObj.Remove(prefab);
    }

    //fromSai
    public virtual void Despawn(T obj)
    {
        if (obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            this.AddObjectToPool(obj);
        }
    }

    protected virtual void AddObjectToPool(T obj)
    {
        this.inPoolObj.Add(obj);
    }
}
