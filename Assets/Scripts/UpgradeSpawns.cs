using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawns : MonoBehaviour
{
    public GameObject movementSpeedUpgradePrefab;
    public GameObject throwSpeedUpgradePrefab;

    public TimeScript timeScript;
    private int time;
    private bool hasBeenSpawned;
    private int nextSpawnedUpgrade;

    public int spawnRate;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        time = timeScript.GetTime();
        hasBeenSpawned = false;
        nextSpawnedUpgrade = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time = timeScript.GetTime();

        if (time % spawnRate == 0 && !hasBeenSpawned)
        {
            SpawnUpgrade();
        }

        if (time % spawnRate == 1)
        {
            hasBeenSpawned = false;
        }
    }

    private void SpawnUpgrade()
    {
        Transform newTransform = gameObject.AddComponent<Transform>();
        Vector3 upgradePlacement = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        if (nextSpawnedUpgrade < 3)
        {
            Instantiate(throwSpeedUpgradePrefab, upgradePlacement, Quaternion.identity);
            nextSpawnedUpgrade++;
        }
        else
        {
            Instantiate(movementSpeedUpgradePrefab, upgradePlacement, Quaternion.identity);
            nextSpawnedUpgrade = 1;
        }
        hasBeenSpawned = true;
    }
}
