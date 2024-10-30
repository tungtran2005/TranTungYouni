using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : EnemyAbstract
{
    [SerializeField] protected PathMoving pathMoving;
    [SerializeField] protected int currentPointIndex = 0;
    [SerializeField] protected Point currentPoint;
    [SerializeField] protected float pointDistance = Mathf.Infinity;
    [SerializeField] protected float pointDistanceLimit = 1f;
    [SerializeField] protected bool isFinish = false;
    [SerializeField] protected bool isMoving = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPathMoving();
    }
    protected virtual void LoadPathMoving()
    {
        if (this.pathMoving != null) return;
        this.pathMoving = GameObject.Find("PathMoving1").GetComponent<PathMoving>();
        Debug.Log(transform.name + " : LoadPathMoving ", gameObject)
;    }
    protected void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        this.LoadMovingStatus();
        if (this.isFinish)
        {
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }
        this.GetNextPoint();
        this.enemyCtrl.Agent.SetDestination(this.currentPoint.transform.position);
    }
    protected virtual void GetNextPoint()
    {
        this.currentPoint = pathMoving.GetPoint(this.currentPointIndex);
        this.pointDistance = Vector3.Distance(this.currentPoint.transform.position, transform.position);
        if (this.pointDistance < pointDistanceLimit) this.currentPointIndex++;
        if(this.currentPointIndex >= this.pathMoving.Points.Count - 1) this.isFinish = true;
    }
    protected virtual void LoadMovingStatus()
    {
        this.isMoving = !this.enemyCtrl.Agent.isStopped;
        this.enemyCtrl.Animator.SetBool("isMoving", this.isMoving);
    }
}
