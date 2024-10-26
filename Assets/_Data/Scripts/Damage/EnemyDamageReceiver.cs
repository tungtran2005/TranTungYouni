using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnemyDespawn despawn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.parent.GetComponentInChildren<EnemyDespawn>();
        Debug.Log(transform.name + " : LoadDespawn", gameObject);
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
    protected override void OnDead()
    {
        base.OnDead();
        this.enemyCtrl.Agent.isStopped = true;
        this.LoadDyingStatus();
        this.StartDelay(2f);
       
       
    }
    //fromChatGPT(DelayTime)
    protected virtual void LoadDyingStatus()
    {
        this.enemyCtrl.Animator.SetBool("isDead", this.isDead);
    }


    public void StartDelay(float delayTime)
    {
        Invoke("DoAction", delayTime);
    }

    private void DoAction()
    {
        Debug.Log("Đã chờ xong, thực hiện hành động tiếp theo");
        // Thực hiện mã tiếp theo tại đây
        this.despawn.DoDespawn();
        this.Reborn();
    }
}
