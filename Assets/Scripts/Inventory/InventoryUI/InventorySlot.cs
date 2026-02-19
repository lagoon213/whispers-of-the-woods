using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text quantityText;
    public bool IsEmpty => !icon.enabled;

    private void Awake()
    {
        icon.enabled = false;
        quantityText.enabled = false;
    }

    public void SetItem(ItemData itemData, int quantity)
    {
        icon.sprite = itemData.ItemIcon;
        icon.enabled = true;
        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
    }

    public void UpdateQuantity(ItemData itemData, int quantity)
    {
        Debug.Log($"Updating quantity to {quantity}");
        if(icon.sprite == itemData.ItemIcon)
        {
                    if (quantity > 0)
        {
            quantityText.text = quantity.ToString();
        }
        else
        {
            ClearSlot();
        }
        }
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
        quantityText.text = string.Empty;
        quantityText.enabled = false;
    }
}
