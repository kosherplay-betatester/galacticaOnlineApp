using UnityEngine;
using System.Collections.Generic;

public class UniverseGenerator : MonoBehaviour
{
    public int seed;
    public int galaxySize = 1000;
    public GameObject starPrefab;

    private List<Vector3> starPositions = new List<Vector3>();

    void Start()
    {
        GenerateUniverse();
    }

    void GenerateUniverse()
    {
        Random.InitState(seed);
        for (int i = 0; i < galaxySize; i++)
        {
            Vector3 starPosition = new Vector3(
                Random.Range(-10000f, 10000f),
                Random.Range(-10000f, 10000f),
                Random.Range(-10000f, 10000f)
            );
            starPositions.Add(starPosition);
            Instantiate(starPrefab, starPosition, Quaternion.identity);
        }
    }

    public Vector3 GetRandomStarPosition()
    {
        if (starPositions.Count == 0)
            return Vector3.zero;
        return starPositions[Random.Range(0, starPositions.Count)];
    }
}
