using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnToggleShop : ButtonAbstract
{
    protected override void OnClick()
    {
        UIShop.Instance.Toggle();
    }
}
