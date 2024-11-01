using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : EnemyMoving
{
    protected override void LoadMovingStatus()
    {
        this.isMoving = !this.enemyCtrl.Agent.isStopped;
        this.enemyCtrl.Animator.SetBool("isFlying", this.isMoving);
    }
}
