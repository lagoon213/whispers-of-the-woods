using System;
using UnityEditor;
using UnityEngine;

public class DetectInteractable : MonoBehaviour
{
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private LayerMask interactableLayer;

    private ObjectDetectedLogic objectDetectedLogic;

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactableLayer))
        {
            var logic = hit.collider.GetComponentInParent<ObjectDetectedLogic>();

            if (logic != null)
            {
                objectDetectedLogic = logic;
                objectDetectedLogic.TriggerOutline();
            }
        }
        else
        {
            if (objectDetectedLogic != null)
            {
                objectDetectedLogic.RemoveOutline();
                objectDetectedLogic = null;
            }
        }
    }
}