using UnityEngine;

public class PickUpMushroom : MonoBehaviour
{
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

    private bool isMushroomDetected;
    private bool IsPickupTriggered;

    private GameObject detectedMushroom;

    void OnDetected(ObjectDetectedLogic detectedObject)
    {
        isMushroomDetected = true;
        detectedMushroom = detectedObject.gameObject;
        Debug.Log("Picked up mushroom");
    }

    void OnDetectionStopped()
    {
        isMushroomDetected = false;
        detectedMushroom = null;
        Debug.Log("Stopped picking up mushroom");
    }

    void PickupStopped()
    {
        IsPickupTriggered = false;
        Debug.Log("Pickup stopped");
    }

    void PickupTriggered()
    {
        IsPickupTriggered = true;
        Debug.Log("Pickup triggered");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMushroomDetected && IsPickupTriggered)
        {
            Destroy(detectedMushroom);
            IsPickupTriggered = false;
        }
    }
}
