using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class InventoryShowItems : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private TMP_Text inventoryText;
    
    void OnEnable()
    {
        inventory.OnItemAdded += OnItemAdded;
    }

    void OnDisable()
    {
        inventory.OnItemAdded -= OnItemAdded;
    }
    
    
    void OnItemAdded(ItemData itemData, int quantity)
    {
         inventoryText.text = "Inventory:\n";
        foreach (var item in inventory.Items)
        {
            inventoryText.text += $"{item.Key.ItemName}: {item.Value}\n";
        }

    }
}
