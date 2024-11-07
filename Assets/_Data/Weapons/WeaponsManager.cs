using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : TungMonoBehaviour
{
    [SerializeField] protected List<WeaponCtrl> weapons;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeapons();
    }
    protected virtual void LoadWeapons()
    {
        if (this.weapons.Count > 0) return;
        foreach (Transform child in transform)
        {
            WeaponCtrl weapon = child.GetComponent<WeaponCtrl>();
            if (weapon == null) continue;
            this.weapons.Add(weapon);
        }
        Debug.Log(transform.name + " : LoadWeapons", gameObject);
    }
}
