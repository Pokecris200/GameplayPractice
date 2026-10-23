using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public InputAction spawnAction;
    private float spawnRangeX = 20f;
    private float spawnPosZ = 20f;
    public float wildSpawnPosX;

    private float startDelay = 2f;
    private float spawnInterval = 1.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnWildAnimal", startDelay, spawnInterval);
        spawnAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnWildAnimal()
    {
        float[] spawnLimits = {-wildSpawnPosX, wildSpawnPosX};
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnLimits[Random.Range(0,2)], 0, Random.Range(0, spawnPosZ));
        float rotationHor = spawnPos.x == wildSpawnPosX ? 90f: -90f;
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation * Quaternion.Euler(0,rotationHor,0));
    }

}
