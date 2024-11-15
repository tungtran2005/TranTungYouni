using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCtrl : ItemDropCtrl
{
    public override ItemType GetItemCode()
    {
        return ItemType.Gold;
    }
}
