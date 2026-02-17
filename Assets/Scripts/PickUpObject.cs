using UnityEngine;


public class PickUpObject : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    private Inventory inventory;

    void OnEnable()
    {
        ObjectDetectedLogic.OnObjectDetected += OnDetected;
        ObjectDetectedLogic.OnObjectDetectionStopped += OnDetectionStopped;
        PlayerInteractor.PickupTriggered += PickupTriggered;
        PlayerInteractor.PickupStopped += PickupStopped;
    }

    void OnDisable()
    {
        ObjectDetectedLogic.OnObjectDetected -= OnDetected;
        ObjectDetectedLogic.OnObjectDetectionStopped -= OnDetectionStopped;
        PlayerInteractor.PickupStopped -= PickupStopped;
        PlayerInteractor.PickupTriggered -= PickupTriggered;
    }

    private bool isObjectDetected;
    private bool IsPickupTriggered;

    private GameObject objectDetected;

    void OnDetected(ObjectDetectedLogic detectedObject)
    {
        isObjectDetected = true;
        objectDetected = detectedObject.gameObject;
        Debug.Log("Object has been detected");
    }

    void OnDetectionStopped()
    {
        isObjectDetected = false;
        objectDetected = null;
        Debug.Log("Stopped detecting object");
    }

    void PickupStopped()
    {
        IsPickupTriggered = false;
        Debug.Log("Pickup trigger stopped");
    }

    void PickupTriggered()
    {
        IsPickupTriggered = true;
        Debug.Log("Pickup triggered");
    }

    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isObjectDetected && IsPickupTriggered)
        {
            Destroy(objectDetected);
            IsPickupTriggered = false;
            inventory.AddItems(itemName, quantity);
        }
    }
}
