using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortGunShop : ItemShop
{
    public override ItemCode GetItemCode()
    {
        return ItemCode.ShortGun;
    }

    public override int SetPrice()
    {
        this.price = 30;
        return this.price;
    }
}
