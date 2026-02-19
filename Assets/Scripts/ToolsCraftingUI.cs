using UnityEngine;

public class ToolsCraftingUI : MonoBehaviour
{
    [SerializeField] private GameObject craftingUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        craftingUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
