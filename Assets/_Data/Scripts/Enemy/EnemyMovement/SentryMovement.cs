using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryMovement : EnemyAbstract
{
    [SerializeField] protected PathMoving pathPatrol;
    [SerializeField] protected Point currentPoint;
    [SerializeField] protected Point nextPoint;
    [SerializeField] protected float pointDistance = Mathf.Infinity;
    [SerializeField] protected float pointDistanceLimit = 1f;
    [SerializeField] protected bool isMoving = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPathPatrol();
    }
    protected virtual void LoadPathPatrol()
    {
        if (this.pathPatrol != null) return;
        this.pathPatrol = GameObject.Find("PathPatrol").GetComponent<PathMoving>();
        this.currentPoint = this.pathPatrol.GetPoint(0);
        this.nextPoint = this.pathPatrol.GetPoint(1);
        Debug.Log(transform.name + ": LoadPathPatrol", gameObject);
    }
    private void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        this.LoadMovingStatus();
        this.pointDistance = Vector3.Distance(this.currentPoint.transform.position, transform.position);
        if (this.pointDistance < pointDistanceLimit) this.SwapPoint(currentPoint, nextPoint);
        this.enemyCtrl.Agent.SetDestination(this.currentPoint.transform.position);
    }
    protected virtual void SwapPoint(Point A, Point B)
    {
        this.currentPoint = B;
        this.nextPoint = A;
    }
    protected virtual void LoadMovingStatus()
    {
        this.isMoving = !this.enemyCtrl.Agent.isStopped;
        this.enemyCtrl.Animator.SetBool("isMoving", this.isMoving);
    }
}