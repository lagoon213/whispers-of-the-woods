using UnityEngine;
using TMPro;

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
    
    
    void OnItemAdded(string itemName, int quantity)
    {
        inventoryText.text = $"Inventory: {itemName} x{quantity}";
    }
}
