using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

//Inventory script
public class Inventory : MonoBehaviour
{
    private Dictionary<ItemData, int> _inventory = new Dictionary<ItemData, int>();
    public event Action OnInventoryChanged;
    [SerializeField] private InventoryPlayer _savedInventory;
    [SerializeField] private GameObject _inventoryUI;
    private bool isOpen = false;
    private int _inventoryPlace = 0;
    private int _quanityInInventory = 0;
    private ItemData selectedItem;
    public int moneyInInventory = 0;

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
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
        if (isOpen)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                CycleInventory();
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                SellItem();
            }
        }
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
        SaveToData();
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

    public void SaveToData()
    {
        if (_savedInventory == null)
        {
            Debug.LogWarning("No ScriptableObject assigned to _savedInventory!");
            return;
        }

        _savedInventory.playerInventory.Clear();

        foreach (var pair in _inventory)
        {
            _savedInventory.playerInventory.Add(new InventoryEntry
            {
                item = pair.Key,
                quantity = pair.Value
            });
        }

        Debug.Log("Saved runtime inventory ScriptableObject");
    }

    public Dictionary<ItemData, int> ReturnInventory()
    {
        return _inventory;
    }
    
    private void ToggleInventory()
    {
        isOpen = !isOpen;
        _inventoryUI.SetActive(isOpen);
        DebugInventoryContents();
        SaveToData();
    }

    private void CycleInventory()
    {
        if (_inventory.Count == 0)
        {
            Debug.Log("Empty Inventory.");
            return;
        }
        //placeholder
        List<ItemData> itemList = new List<ItemData>(_inventory.Keys);
        _inventoryPlace++;
        if (_inventoryPlace >= itemList.Count)
        {
            _inventoryPlace = 0;
        }
        selectedItem = itemList[_inventoryPlace];
        _quanityInInventory = _inventory[selectedItem];
        Debug.Log($"Slot {_inventoryPlace + 1}: {selectedItem.itemName} X {_quanityInInventory}");
    }

    private void SellItem()
    {
        if (selectedItem == null)
        {
            Debug.Log("No Item selected.");
            return;
        }
        int currentQuantity;
        if (_inventory.TryGetValue(selectedItem, out currentQuantity))
        {
            currentQuantity -= 1;
            //inInventory = true;
            _inventory[selectedItem] = currentQuantity;
            Debug.Log($"Sold one item of {selectedItem.itemName}. Remaining quanity of item is {currentQuantity}");
            switch (selectedItem.itemName)
            {
                case "Onion":
                    {
                        moneyInInventory += 5;
                        break;
                    }

                case "Potato":
                    {
                        moneyInInventory += 3;
                        break;
                    }
                case "Strawberry":
                    {
                        moneyInInventory += 2; break;
                    }
                case "Sunflower":
                    {  moneyInInventory += 8; break;}
                default:
                    { Debug.Log("Item not found in database."); break; }
            }
        }
    }
}
