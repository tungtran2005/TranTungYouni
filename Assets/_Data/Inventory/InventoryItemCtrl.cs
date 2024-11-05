using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventoryItemCtrl : InventoryCtrl
{
    public override InventoryType GetInventoryType()
    {
        return InventoryType.Item;
    }
}
