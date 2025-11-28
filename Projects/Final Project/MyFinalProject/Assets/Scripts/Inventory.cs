using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<ItemData, int> _inventory = new Dictionary<ItemData, int>();
    public event Action OnInventoryChanged;
    [SerializeField] private InventoryPlayer _savedInventory;

    //Things to do before submitting for the final final. Get the scriptable player inventory involved,
    //Open inventory by pressing i
    //Shop by pressing s maybe
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_savedInventory != null && _savedInventory.playerInventory.Count > 0)
        {
            LoadFromData();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(ItemData item)
    {
        //bool inInventory = false;
        int amount = item.itemQuantity;
        int currentQuantity;
        if (_inventory.TryGetValue(item, out currentQuantity))
        {
            //inInventory = true;
            _inventory[item] = amount + currentQuantity;
            Debug.Log("Increase to inventory!");
        }
        else { _inventory.Add(item, amount); }
        //inInventory = false;
        OnInventoryChanged?.Invoke();
        DebugInventoryContents();
    }

    private void DebugInventoryContents()
    {
        foreach (var pair in _inventory)
        {
            Debug.Log("Inventory contains: " + pair.Key.itemName + " x" + pair.Value);
        }
    }

    private void LoadFromData()
    {
        foreach (var entry in _savedInventory.playerInventory)
        {
            _inventory[entry.item] = entry.quantity;
        }
        Debug.Log("Load from Inventory!");
        OnInventoryChanged?.Invoke();
    }

    //private void AddItemToData(ItemData)
    //{
    //    //placeholder for adding to scriptiable object
    //}

    public Dictionary<ItemData, int> ReturnInventory()
    {
        return _inventory;
    }
}
