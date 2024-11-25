using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandShop : ItemShop
{
    public override ItemCode GetItemCode()
    {
        return ItemCode.Wand;
    }

    public override int SetPrice()
    {
        this.price = 5;
        return this.price;
    }

}
