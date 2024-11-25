using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseShop : ButtonAbstract
{
    protected override void OnClick()
    {
        UIShop.Instance.Hide();
    }
}
