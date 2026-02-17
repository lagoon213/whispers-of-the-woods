using UnityEditor;
using UnityEngine;

public class DetectInteractable : MonoBehaviour
{
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private LayerMask interactableLayer;
    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out RaycastHit hit, interactRange, interactableLayer);

        if (hit.collider != null)
        {
            Debug.Log("Interactable detected: " + hit.collider.name);
        }
    }
}
