using System;
using UnityEngine;

public class ObjectDetectedLogic : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    private PickUpObject pickUpObject;

    [SerializeField] private Material outlineMaterial;
    [SerializeField] private Material originalMaterial;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        pickUpObject = GetComponentInParent<PickUpObject>();
        RemoveOutline();
    }


    public void TriggerOutline()
    {
        meshRenderer.materials = new Material[] { originalMaterial, outlineMaterial };
        pickUpObject.TriggerPickUpObject();
    }

    public void RemoveOutline()
    {
        meshRenderer.materials = new Material[] { originalMaterial };
    }
}
