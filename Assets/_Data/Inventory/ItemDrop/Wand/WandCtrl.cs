using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandCtrl : ItemDropCtrl
{
    public override ItemType GetItemCode()
    {
        return ItemType.Wand;
    }
}
