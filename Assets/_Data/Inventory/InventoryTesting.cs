using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryTesting : TungMonoBehaviour
{

    [ProButton]
    public virtual void AddTestItems(ItemCode itemCode, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InventoriesManager.Instance.AddItem(itemCode, 1);
        }
    }

    [ProButton]
    public virtual void RemoveTestItems(ItemCode itemCode, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InventoriesManager.Instance.RemoveItem(itemCode, 1);
        }
    }
}