using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBarHP : TungMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected Slider slider;
    [SerializeField] protected int maxHP;
    [SerializeField] protected int minHP;
    private void FixedUpdate()
    {
        this.DisPlayHP();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadSilder();
        this.LoadHP();
        
    }
    protected virtual void LoadSilder()
    {
        if (this.slider != null) return;
        this.slider = GetComponentInChildren<Slider>();
        Debug.Log(transform.name + " : LoadSilder", gameObject);
    }
    protected virtual void LoadHP()
    {
        this.maxHP = enemyCtrl.EnemyDamageReceiver.MaxHP;
        this.minHP = 0;
        this.slider.maxValue =this.maxHP;
        this.slider.minValue =this.minHP;
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl ", gameObject);
    }
    protected virtual void DisPlayHP()
    {
        this.slider.value = this.enemyCtrl.EnemyDamageReceiver.CurrentHP;
    }
}
