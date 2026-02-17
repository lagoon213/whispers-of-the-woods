using System;
using UnityEngine;

public class ObjectDetectedLogic : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private Material originalMaterial;

    public static event Action<ObjectDetectedLogic> OnObjectDetected;
    public static event Action OnObjectDetectionStopped;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        RemoveOutline();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerOutline()
    {
        meshRenderer.materials = new Material[] { originalMaterial, outlineMaterial };
        OnObjectDetected?.Invoke(this);
    }

    public void RemoveOutline()
    {
        meshRenderer.materials = new Material[] { originalMaterial };
        OnObjectDetectionStopped?.Invoke();
    }
}
