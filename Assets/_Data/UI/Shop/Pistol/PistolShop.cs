using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShop : ItemShop
{
    public override ItemCode GetItemCode()
    {
        return ItemCode.Pistol;
    }

    public override int SetPrice()
    {
        this.price = 15;
        return this.price;
    }
}
