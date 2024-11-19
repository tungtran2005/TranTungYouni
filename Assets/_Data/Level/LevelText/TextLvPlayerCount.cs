using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLvPlayerCount : TextAbstract
{
    [SerializeField] protected LevelByPlayerExp levelByPlayerExp;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevelByPlayerExp();
    }
    private void FixedUpdate()
    {
        this.UpdateLevel();
    }
    protected virtual void UpdateLevel()
    {
        this.textPro.text = this.GetLevel();
    }
    protected virtual void LoadLevelByPlayerExp()
    {
        if (this.levelByPlayerExp != null) return;
        this.levelByPlayerExp = Transform.FindAnyObjectByType<LevelByPlayerExp>();
        Debug.Log(transform.name + " : LoadLevelByPlayerExp", gameObject);
    }
    protected virtual string GetLevel()
    {
        return this.levelByPlayerExp.CurrentLevel.ToString();
    }
}
