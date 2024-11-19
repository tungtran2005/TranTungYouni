using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByPlayerExp : LevelByItem
{
    protected override ItemCode GetItemCode()
    {
        return ItemCode.PlayerExp;
    }
}
