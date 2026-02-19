using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    private Dictionary<ItemData, int> items = new(); 
    [SerializeField] private InventoryBar inventoryBar;

    public IReadOnlyDictionary<ItemData, int> Items => items;

    [SerializeField] private GameObject NewMushroomCanvas;

    public event Action<ItemData, int> OnItemAdded;
    public event Action<ItemData, int> OnItemRemoved;


    public void AddItems( ItemData itemData, int quantity)
    {
        if (!items.ContainsKey(itemData))
        {
            items[itemData] = 0;
            NewMushroomTimer();
            inventoryBar.TryAddingItemToBar(itemData, quantity);
        }
        items[itemData] += quantity;
        inventoryBar.UpdateItemInBar(itemData, items[itemData]);
        OnItemAdded?.Invoke(itemData, items[itemData]);
    }

    public void ReturnAmount(ItemData itemData)
    {
        if (items.ContainsKey(itemData))
        {
            Debug.Log($"You have {items[itemData]} {itemData.ItemName}(s) in your inventory.");
        }
        else
        {
            Debug.Log($"You have no {itemData.ItemName} in your inventory.");
        }
    }

    public void RemoveItems(ItemData itemData, int quantity)
    {
        if (items.ContainsKey(itemData) && items[itemData] >= quantity)
        {
            items[itemData] -= quantity;
            OnItemRemoved?.Invoke(itemData, items[itemData]);
        }
        else
        {
            Debug.Log($"Not enough {itemData.ItemName} in inventory to remove.");
        }
    }

    void Start()
    {
        HideNewMushroomCanvas();
    }

    private void NewMushroomTimer()
    {
        NewMushroomCanvas.SetActive(true);
        Invoke("HideNewMushroomCanvas", 3f);
    }

    private void HideNewMushroomCanvas()
    {
        NewMushroomCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
