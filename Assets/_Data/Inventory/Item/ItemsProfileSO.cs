using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObject/ItemProfile", order = 1)]
public class ItemsProfileSO : ScriptableObject
{
    public InventoryType inventoryType;
    public Sprite sprite;
    public ItemCode itemType;
    public string itemName;
    public int price;
    public bool isStackable = false;
    public int maxStack = 99;
}
