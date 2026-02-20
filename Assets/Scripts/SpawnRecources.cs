using UnityEngine;

public class SpawnRecources : MonoBehaviour
{
    [SerializeField] private GameObject[] resourcePrefabs;
    [SerializeField] private int numberOfResources;
    [SerializeField] private Terrain terrain;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 terrainSize = terrain.terrainData.size;
        Vector3 terrainPosition = terrain.transform.position;
        for (int i = 0; i < numberOfResources; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(terrainPosition.x, terrainPosition.x + terrainSize.x),
                0,
                Random.Range(terrainPosition.z, terrainPosition.z + terrainSize.z)
            );

            randomPosition.y = terrain.SampleHeight(randomPosition);

            GameObject resourcePrefab = resourcePrefabs[Random.Range(0, resourcePrefabs.Length)];
            Instantiate(resourcePrefab, randomPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
