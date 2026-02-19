using UnityEngine;
using UnityEngine.UI;

public class InventoryBar : MonoBehaviour
{
    [SerializeField] private InventorySlot[] inventorySlots;

    void Start()
    {

    }

    public void TryAddingItemToBar(ItemData itemData, int quantity)
    {
        foreach (var slot in inventorySlots)
        {
            if (slot.IsEmpty)
            {
                slot.SetItem(itemData, quantity);
                return;
            }
        }
    }

    public void UpdateItemInBar(ItemData itemData, int quantity)
    {
        foreach (var slot in inventorySlots)
        {
            if (!slot.IsEmpty)
            {
                slot.UpdateQuantity(itemData, quantity);
                return;
            }
        }
    }

}
