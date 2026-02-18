using UnityEngine;

public class ChopTree : MonoBehaviour
{
    private bool isPickupTriggered;

    void OnEnable()
    {
        PlayerInteractor.PickupTriggered += () => isPickupTriggered = true;
        PlayerInteractor.PickupStopped += () => isPickupTriggered = false;
    }

    void OnDisable()
    {
        PlayerInteractor.PickupTriggered -= () => isPickupTriggered = true;
        PlayerInteractor.PickupStopped -= () => isPickupTriggered = false;
    }

    public void Chop()
    {
        if (isPickupTriggered)
        {
            TreeHealth treeHealth = GetComponentInParent<TreeHealth>();
            if (treeHealth != null)
            {
                treeHealth.TakeDamage(null);
                treeHealth.DestroyTree();
                isPickupTriggered = false;
            }
        }
    }
}
