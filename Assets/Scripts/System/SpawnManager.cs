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
    private bool canSpawn;
    // Start is called before the first frame update
    private void Awake()
    {
       gameManager.onGameStateChange += onUpdateSpawner;
       activeRunTime = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (canSpawn)
        {
            activeRunTime += Time.deltaTime;
            activeSpawnTime += Time.deltaTime;
            if (activeSpawnTime >= spawnFrequency)
            {
                DecideEnemySpawn();
                activeSpawnTime -= spawnFrequency;
            }
        }
    }

    private void onUpdateSpawner(GameManager.State state)
    {
        canSpawn = false;
        switch (state)
        {
            case GameManager.State.Start:
                break;
            case GameManager.State.Running:
                canSpawn = true;
                break;
            case GameManager.State.Pause:
                break;
            case GameManager.State.End:
                break;
            default:
                break;
        }
    }

    private void DecideEnemySpawn()
    {
        if (activeRunTime >= 10)
        {
            SpawnPrefab(t3PrefabEnemy);
        }
        if (activeRunTime >= 5)
        {
            SpawnPrefab(t2PrefabEnemy);
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
        //Debug.Log(spawnRegions[randSpawnIndex].position);
        Vector3 SpawnPosition = spawnRegions[randSpawnIndex].position;
        SpawnPosition.y = SpawnPosition.y - 8;
        Instantiate(prefab, SpawnPosition, spawnRegions[randSpawnIndex].rotation);
    }
}
