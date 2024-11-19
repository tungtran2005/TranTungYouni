using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TextLevel : Text3DAbstract
{
    protected virtual void FixedUpdate()
    {
        this.UpdateLevel();
    }

    protected virtual void UpdateLevel()
    {
        this.textPro.text = this.GetLevel();
    }

    protected abstract string GetLevel();
}
