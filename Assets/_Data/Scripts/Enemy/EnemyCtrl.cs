using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyCtrl : PoolObj
{
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAgent();
        this.LoadAnimator();
        this.LoadDamageReceiver();
    }
    protected virtual void LoadAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        Debug.Log(transform.name + " : LoadAgent", gameObject);
    }
    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = transform.Find("Model").GetComponent<Animator>();
        Debug.Log(transform.name + " : LoadAnimator", gameObject);
    }
    protected virtual void LoadDamageReceiver()
    {
        if(this.damageReceiver != null) return;
        this.damageReceiver = transform.Find("DamageReceiver").GetComponent<DamageReceiver>();
        Debug.Log(transform.name + " : LoadDamageReceiver", gameObject);
    }
}
