using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingTable : MonoBehaviour
{
    [SerializeField] private CraftingUI craftingUI;


    private bool openTriggered;


    public void OnOpen(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            openTriggered = true;
        }
        if (value.canceled)
        {
            openTriggered = false;
        }
    }

    public void Detected()
    {
        if (openTriggered)
        {
            craftingUI.OpenCrafting();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
