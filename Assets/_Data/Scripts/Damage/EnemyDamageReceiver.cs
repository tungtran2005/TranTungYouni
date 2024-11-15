using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCapsuleCollider();
    }
    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        this.capsuleCollider.center = new Vector3(0, 1, 0);
        this.capsuleCollider.radius = 0.4f;
        this.capsuleCollider.height = 1.7f;
        //this.capsuleCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadCapsuleCollider", gameObject);
    }
    public override void Deduct(int damage)
    {
        base.Deduct(damage);
        this.LoadHitStatus();
    }
    protected virtual void LoadHitStatus()
    {
        this.enemyCtrl.Animator.SetTrigger("Hit");
    }
    public override void OnDead()
    {
        base.OnDead();
        ItemDropSpawnerCtrl.Instance.DropMany(ItemType.Gold, transform.parent.position, 3);
        ItemDropSpawnerCtrl.Instance.DropMany(ItemType.Silver, transform.parent.position, 5);
        ItemDropSpawnerCtrl.Instance.Drop(ItemType.Wand, transform.parent.position, 1);
        InventoriesManager.Instance.AddItem(ItemType.PlayerExp, 1);
        InventoriesManager.Instance.AddItem(ItemType.Wand, 1);
        this.enemyCtrl.Agent.isStopped = true;
        this.LoadDyingStatus();
        this.capsuleCollider.enabled = false;
        Invoke(nameof(this.DoDespawn), 5f);
    }
    protected virtual void DoDespawn()
    {
        this.enemyCtrl.Despawn.DoDespawn();
    }
    protected virtual void LoadDyingStatus()
    {
        this.enemyCtrl.Animator.SetBool("isDead", this.isDead);
    }
    protected override void Reborn()
    {
        base.Reborn();
        this.capsuleCollider.enabled = true;
    }
}
