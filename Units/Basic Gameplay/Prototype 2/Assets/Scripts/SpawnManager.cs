using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrehabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Spawns random animals from an array based on the random range
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrehabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrehabs[animalIndex], spawnPos, animalPrehabs[animalIndex].transform.rotation);
    }
}
