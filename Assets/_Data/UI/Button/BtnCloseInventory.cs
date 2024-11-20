using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseInventory : ButtonAbstract
{

    protected override void OnClick()
    {
        UIInventory.Instance.Hide();
    }
}
