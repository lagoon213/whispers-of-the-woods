using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int AmountOfWoodLogsToDrop;
    [SerializeField] private GameObject treeStump;
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private GameObject woodLog;
    [SerializeField] private GameObject player;
    [SerializeField] private float height = 1f;
    [SerializeField] private float radius = 3f;

    private GameObject healthBarObject;
    private Image healthBarFill;
    
    private int currentHealth;
    public void TakeDamage(int? damageAmount)
    {
        if (currentHealth == maxHealth)
        {
            CreateHealthBar();
        }
        currentHealth -= damageAmount ?? 1;
    }

    public void DestroyTree()
    {
        if (currentHealth <= 0)
        {
            DropWoodLog();
            healthBarObject.SetActive(false);
            Destroy(gameObject);
            LeaveTreeStump();
        }
    }

    private void CreateHealthBar()
    {
        healthBarObject = Instantiate(healthBarPrefab, transform);
        healthBarFill = healthBarObject.GetComponentsInChildren<Image>()[1];
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
        float heightOffset = 0.5f;
        for (int i = 0; i < AmountOfWoodLogsToDrop; i++)
        {   
            Vector3 treePosition = transform.position;
            Vector3 dropPosition = treePosition + Vector3.up * (height + i * heightOffset);
            Instantiate(woodLog, dropPosition, Quaternion.identity);
        }
    }

    private void LeaveTreeStump()
    {
        Instantiate(treeStump, transform.position, Quaternion.identity);
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (healthBarObject != null && healthBarObject.activeInHierarchy)
        {
            UpdateUI();
        }
    }
}
