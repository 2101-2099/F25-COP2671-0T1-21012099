using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

//Inventory UI
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Transform _inventoryPanel;
    [SerializeField] private GameObject _slot;
    private InventorySlotUI newInventorySlot;

    private List<GameObject> _slotList = new List<GameObject>();
    private void Start()
    {
        if (_inventory != null)
            _inventory.OnInventoryChanged += UpdateUI;

        UpdateUI();
    }

    public void UpdateUI()
    {
        ClearUI();

        foreach (var pair in _inventory.ReturnInventory())
        {
            //placeholder
            GameObject spawnInventorySlot = Instantiate(_slot, _inventoryPanel.transform);
            _slotList.Add(spawnInventorySlot);

            newInventorySlot = spawnInventorySlot.GetComponent<InventorySlotUI>();
            newInventorySlot.NewSlot(pair.Key, pair.Value);
            Debug.Log("Item added to UI" + pair.Key.itemName + " + " + pair.Value.ToString());
        }
        Debug.Log("Updated UI");
    }

    private void ClearUI()
    {
        foreach (var slot in _slotList)
        {
            Destroy(slot);
        }
        _slotList.Clear();
    }
}
