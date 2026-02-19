using UnityEngine;
using UnityEngine.UI;

public class TreeHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private int AmountOfWoodLogsToDrop;
    [SerializeField] private GameObject treeStump;
    [SerializeField] private GameObject healthBarObject;
    [SerializeField] private GameObject woodLog;
    [SerializeField] private GameObject player;
    [SerializeField] private float height = 1f;
    [SerializeField] private float radius = 3f;
    
    private int currentHealth;
    public void TakeDamage(int? damageAmount)
    {
        if (currentHealth == maxHealth)
        {
            TriggerUI();
        }
        currentHealth -= damageAmount ?? 1;
    }

    public void DestroyTree()
    {
        if (currentHealth <= 0)
        {
            for (int i = 0; i < AmountOfWoodLogsToDrop; i++)
            {
                DropWoodLog();
            }
            healthBarObject.SetActive(false);
            Destroy(gameObject);
            LeaveTreeStump();
        }
    }

    public void UpdateUI()
    {
        healthBarFill.fillAmount = (float)currentHealth / maxHealth;
        Vector3 position = transform.position;
        Vector3 DirectionToPlayer = player.transform.position - position;
        DirectionToPlayer.y = 0; 
        Vector3 dir = DirectionToPlayer.normalized;
        Vector3 offset = dir * radius + Vector3.up * height;
        healthBarObject.transform.position = position + offset;
        Transform cam = Camera.main.transform;
        healthBarObject.transform.rotation = Quaternion.LookRotation(healthBarObject.transform.position - cam.position, Vector3.up);
    }

    private void DropWoodLog()
    {

            Vector3 treePosition = transform.position;
            Vector3 dropPosition = treePosition + Vector3.up * 1f;
            Instantiate(woodLog, dropPosition, Quaternion.identity);
    }

    private void LeaveTreeStump()
    {
        // Implement logic to replace the tree with a stump if desired
        Instantiate(treeStump, transform.position, Quaternion.identity);
    }

    public void TriggerUI()  
    {
        healthBarObject.SetActive(true);

    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBarObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarObject.activeInHierarchy)
        {
            UpdateUI();
        }
    }
}
