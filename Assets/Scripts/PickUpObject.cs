using UnityEngine;


public class PickUpObject : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    private Inventory inventory;

    void OnEnable()
    {
        PlayerInteractor.PickupTriggered += PickupTriggered;
        PlayerInteractor.PickupStopped += PickupStopped;
    }

    void OnDisable()
    {
        PlayerInteractor.PickupStopped -= PickupStopped;
        PlayerInteractor.PickupTriggered -= PickupTriggered;
    }

    private bool IsPickupTriggered;


    void PickupStopped()
    {
        IsPickupTriggered = false;
    }

    void PickupTriggered()
    {
        IsPickupTriggered = true;
    }

    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }

    public void TriggerPickUpObject()
    {
        if (IsPickupTriggered)
        {
            Destroy(gameObject);
            IsPickupTriggered = false;
            inventory.AddItems(itemName, quantity);
        }
    }
}
