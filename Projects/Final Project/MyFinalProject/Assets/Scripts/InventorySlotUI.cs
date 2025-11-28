using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI quantityText;
    private int _amount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void NewSlot(ItemData itemData, int quantity)
    {
        _amount = quantity;
        icon.sprite = itemData.itemIcon;
        itemName.text = itemData.itemName;
        quantityText.text = _amount.ToString();
        Debug.Log(itemName.text + " added to a new slot." + "\n" + _amount.ToString() + " added.");
    }
}
