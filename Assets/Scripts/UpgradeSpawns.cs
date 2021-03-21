using UnityEngine;

public class UpgradeSpawns : MonoBehaviour
{
    public GameObject movementSpeedUpgradePrefab;
    public GameObject throwSpeedUpgradePrefab;

    private TimeScript timeScript;
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
        timeScript = GameObject.FindGameObjectWithTag("Time").GetComponent<TimeScript>();
        time = timeScript.GetTime();

        hasBeenSpawned = false;
        nextSpawnedUpgrade = 1;
    }

    /// <summary>
    /// Checks and sets condition for upgrade spawns
    /// </summary>
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

    /// <summary>
    /// Spawns upgrade based on given conditions
    /// </summary>
    private void SpawnUpgrade()
    {
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
