using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnToggleInventory : ButtonAbstract
{
    protected override void OnClick()
    {
        UIInventory.Instance.Toggle();
    }
    
}
