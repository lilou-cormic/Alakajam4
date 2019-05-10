using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public static LevelSpawner Instance;

    [SerializeField]
    private GameObject EnemyPrefab = null;

    [SerializeField]
    private GameObject ParachutePrefab = null;

    private Camera Camera = null;

    private float enemySpawnRate = 1.9f;

    private float parachuteSpawnRate = 0.7f;

    private float nextEnemyTime = 0f;

    private float nextParachuteTime = 0f;

    private bool shouldSpawn = true;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Camera = Camera.main;

        nextEnemyTime = Time.time + enemySpawnRate;
        nextParachuteTime = Time.time + nextParachuteTime;
    }

    private void FixedUpdate()
    {
        if (!shouldSpawn)
            return;

        if (Time.time >= nextEnemyTime)
        {
            float x = Random.Range(-6f, 6f);

            Instantiate(EnemyPrefab, new Vector3(x, Camera.transform.position.y - 5, 0), Quaternion.identity);

            nextEnemyTime = Time.time + enemySpawnRate;
        }

        if (Time.time >= nextParachuteTime)
        {
            float x = Random.Range(-5.75f, 5.75f);

            Instantiate(ParachutePrefab, new Vector3(x, Camera.transform.position.y - 5, 0), Quaternion.identity);

            nextParachuteTime = Time.time + parachuteSpawnRate;
        }
    }

    public void StopSpawning()
    {
        shouldSpawn = false;
    }
}
