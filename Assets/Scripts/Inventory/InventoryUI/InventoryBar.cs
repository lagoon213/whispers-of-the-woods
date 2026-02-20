using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryBar : MonoBehaviour
{
    private VisualElement root;

    private List<SlotUI> slots = new();

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        var slotElements = root.Query<VisualElement>(className: "ItemSlot").ToList();

        slots = slotElements.Select(e => new SlotUI(e)).ToList();

        foreach (var s in slots)
            s.Clear();
    }

    public void AddOrUpdate(ItemData itemData, int addQuantity)
    {
        var existing = slots.FirstOrDefault(s => s.Item == itemData);
        if (existing != null)
        {
            existing.Quantity += addQuantity;
            existing.Refresh();
            return;
        }

        var empty = slots.FirstOrDefault(s => s.IsEmpty);
        if (empty != null)
        {
            empty.Item = itemData;
            empty.Quantity = addQuantity;
            empty.Refresh();
            return;
        }
    }

    public void SetQuantity(ItemData itemData, int quantity)
    {
        var existing = slots.FirstOrDefault(s => s.Item == itemData);
        if (existing == null) return;

        if (quantity <= 0)
        {
            existing.Clear();
            return;
        }

        existing.Quantity = quantity;
        existing.Refresh();
    }

    private class SlotUI
    {
        private readonly VisualElement slot;
        private readonly VisualElement icon;
        private readonly Label quantityLabel;

        public ItemData Item;
        public int Quantity;

        public bool IsEmpty => Item == null;

        public SlotUI(VisualElement slotElement)
        {
            slot = slotElement;

            icon = slot.Q<VisualElement>(className: "ItemImage");
            quantityLabel = slot.Q<Label>(className: "ItemQuantity");
        }

        public void Refresh()
        {
            if (IsEmpty)
            {
                Clear();
                return;
            }

            icon.style.backgroundImage = new StyleBackground(Item.ItemIcon);

            if (Quantity <= 1)
            {
                quantityLabel.text = "";
                quantityLabel.style.display = DisplayStyle.None;
            }
            else
            {
                quantityLabel.text = Quantity.ToString();
                quantityLabel.style.display = DisplayStyle.Flex;
            }
        }

        public void Clear()
        {
            Item = null;
            Quantity = 0;

            icon.style.backgroundImage = StyleKeyword.None;
            quantityLabel.text = "";
            quantityLabel.style.display = DisplayStyle.None;
        }
    }
}