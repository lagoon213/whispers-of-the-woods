using System;
using UnityEditor;
using UnityEngine;

public class DetectInteractable : MonoBehaviour
{
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private LayerMask treeInteractableLayer;
    [SerializeField] private LayerMask UsableInteractableLayer;

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

        if(Physics.Raycast(ray, out RaycastHit open, interactRange, UsableInteractableLayer))
        {
            CraftingTable usable = open.collider.GetComponentInParent<CraftingTable>();
            if (usable != null)
            {
                usable.Detected();
            }
        }

        if (Physics.Raycast(ray, out RaycastHit pickupHit, interactRange, treeInteractableLayer))
        {
            ChopTree chopTree = pickupHit.collider.GetComponentInParent<ChopTree>();
            if (chopTree != null)
            {
                chopTree.Chop();
            }
        }
    }
}