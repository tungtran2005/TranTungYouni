using System.Collections;
using System;
using UnityEngine;
[Serializable]
public class ItemInventory
{
    protected int itemId;
    public int ItemID => itemId;

    protected ItemsProfileSO itemProfile;
    public ItemsProfileSO ItemProfile => itemProfile;

    [SerializeField] protected string itemName;

    public int itemCount;
    public ItemInventory(ItemsProfileSO itemProfile, int itemCount)
    {
        this.itemProfile = itemProfile;
        this.itemCount = itemCount;
        this.itemName = this.itemProfile.itemName;
    }
    public virtual void SetId(int id)
    {
        this.itemId = id;
    }
    public virtual void SetName(string name)
    {
        this.itemName = name;
    }
    public virtual string GetName()
    {
        if(this.itemName == null || this.itemName == "") this.itemName = this.itemProfile.itemName;
        return this.itemName;
    }
    public virtual bool Add(int num)
    {
        if (!this.CanAdd(num)) return false;
        this.itemCount += num;
        return true;
    }
    public virtual bool CanAdd(int num)
    {
        if (!this.itemProfile.isStackable ||(this.itemCount + num ) > this.itemProfile.maxStack ) return false;
        return true;
    }
    public virtual bool Deduct(int num)
    {
        if (!this.CanDeduct(num)) return false;
        this.itemCount -= num;
        return true;
    }
    public virtual bool CanDeduct(int num)
    {
        return (this.itemCount >= num);
    }
}
