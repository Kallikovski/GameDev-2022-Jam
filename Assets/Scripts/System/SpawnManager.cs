using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<Transform> spawnRegions;
    [SerializeField] private GameObject t1PrefabEnemy;
    [SerializeField] private GameObject t2PrefabEnemy;
    [SerializeField] private GameObject t3PrefabEnemy;

    [SerializeField] private float spawnFrequency;

    private float activeRunTime;
    private float activeSpawnTime;
    // Start is called before the first frame update
    private void Awake()
    {
        activeRunTime = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        activeRunTime += Time.deltaTime;
        activeSpawnTime += Time.deltaTime;
        if (activeSpawnTime >= spawnFrequency)
        {
            Debug.Log(Mathf.Floor(activeRunTime));
            DecideEnemySpawn();
            activeSpawnTime -= spawnFrequency;
        }
    }

    private void DecideEnemySpawn()
    {
        if (activeRunTime >= 10)
        {
            SpawnPrefab(t2PrefabEnemy);
        }
        if (activeRunTime >= 5)
        {
            SpawnPrefab(t3PrefabEnemy);
        }
        else
        {
            SpawnPrefab(t1PrefabEnemy);
        }
        //SpawnPrefab(t1PrefabEnemy);
    }

    private void SpawnPrefab(GameObject prefab)
    {
        int randSpawnIndex = Random.Range(0, spawnRegions.Count);
        Debug.Log(spawnRegions[randSpawnIndex].position);
        Instantiate(prefab, spawnRegions[randSpawnIndex].position, spawnRegions[randSpawnIndex].rotation);
    }
}
