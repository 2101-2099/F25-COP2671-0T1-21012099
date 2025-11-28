using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InventoryEntry
{
    public ItemData item;
    public int quantity;
}
[CreateAssetMenu(menuName = "Inventory/Player Inventory Data")]
public class InventoryPlayer : ScriptableObject
{
    public List<InventoryEntry> playerInventory = new List<InventoryEntry>();
}
