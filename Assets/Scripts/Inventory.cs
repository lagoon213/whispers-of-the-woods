using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> items = new(); 

    public IReadOnlyDictionary<string, int> Items => items;

    [SerializeField] private GameObject NewMushroomCanvas;

    public event Action<string, int> OnItemAdded;
    public event Action<string, int> OnItemRemoved;


    public void AddItems( string itemName, int quantity)
    {
        if (!items.ContainsKey(itemName))
        {
            items[itemName] = 0;
            NewMushroomTimer();
        }
        items[itemName] += quantity;
        Debug.Log($"Added {quantity} {itemName}(s) to inventory. Total: {items[itemName]}");
        OnItemAdded?.Invoke(itemName, items[itemName]);
    }

    public void ReturnAmount(string itemName)
    {
        if (items.ContainsKey(itemName))
        {
            Debug.Log($"You have {items[itemName]} {itemName}(s) in your inventory.");
        }
        else
        {
            Debug.Log($"You have no {itemName} in your inventory.");
        }
    }

    public void RemoveItems(string itemName, int quantity)
    {
        if (items.ContainsKey(itemName) && items[itemName] >= quantity)
        {
            items[itemName] -= quantity;
            OnItemRemoved?.Invoke(itemName, items[itemName]);
            Debug.Log($"Removed {quantity} {itemName}(s) from inventory. Remaining: {items[itemName]}");
        }
        else
        {
            Debug.Log($"Not enough {itemName} in inventory to remove.");
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
