using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ShopEntry
{
    public ItemData item;
    public int quantity;
    public int price;
}
[CreateAssetMenu(menuName = "Inventory/Shop Inventory Data")]
public class ShopUISO : ScriptableObject
{
    public List<InventoryEntry> playerInventory = new List<InventoryEntry>();
}
