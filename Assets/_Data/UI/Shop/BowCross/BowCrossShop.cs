using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowCrossShop : ItemShop
{
    public override ItemCode GetItemCode()
    {
        return ItemCode.Crossbow;
    }

    public override int SetPrice()
    {
        this.price = 10;
        return this.price;
    }
}
