using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] treePrefabs;
    [SerializeField] private int numberOfTrees;
    [SerializeField] private Terrain terrain;
    [SerializeField] private float minDistanceBetweenTrees;

    private List<Vector3> treePositions;

    void Start()
    {
        treePositions = new List<Vector3>();
        SpawnTrees();
    }

    bool IsTooCloseToExistingTree(Vector3 position, float minDistance)
    {
        foreach (var treePos in treePositions)
        {
            if (Vector3.Distance(position, treePos) < minDistance)
            {
                return true;
            }
        }
        return false;
    }

    void SpawnTrees()
    {
        for (int i = 0; i < numberOfTrees; i++)
        {
            
            Vector3 randomPosition = new Vector3(
                Random.Range(0, terrain.terrainData.size.x),
                0,
                Random.Range(0, terrain.terrainData.size.z)
            );

            randomPosition.y = terrain.SampleHeight(randomPosition);

            if (IsTooCloseToExistingTree(randomPosition, minDistanceBetweenTrees))
            {
                i--;
                continue;
            }

            treePositions.Add(randomPosition);

            GameObject treePrefab = treePrefabs[Random.Range(0, treePrefabs.Length)];
            Instantiate(treePrefab, randomPosition, Quaternion.identity);
        }

    }
}
