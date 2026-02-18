using UnityEngine;


public class PickUpObject : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    private Inventory inventory;

    void OnEnable()
    {
        PlayerInteractor.PickupTriggered += () => IsPickupTriggered = true;
        PlayerInteractor.PickupStopped += () => IsPickupTriggered = false;
    }

    void OnDisable()
    {
        PlayerInteractor.PickupStopped -= () => IsPickupTriggered = false;
        PlayerInteractor.PickupTriggered -= () => IsPickupTriggered = true;
    }

    private bool IsPickupTriggered;

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
