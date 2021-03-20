using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    public Transform spawn6;
    public Transform spawn7;
    public Transform spawn8;
    public Transform spawn9;

    public GameObject ratPrefab;
    public GameObject batPrefab;
    public TimeScript timeScript;

    private int time;

    public int increasedSpawnratePerSeconds;
    public int spawnratePerSeconds;
    public int StartingRatAmount;

    private int spawnRate;
    private bool hasBeenSpawned;
    private bool spawnrateReadjusted;
    private int spawnsRatPerSpawntick;
    private int spawnsBatPerSpawntick;

    void Start()
    {
        time = timeScript.GetTime();
        hasBeenSpawned = false;
        spawnrateReadjusted = false;
        spawnsRatPerSpawntick = 1;
        spawnsBatPerSpawntick = 0;
        spawnRate = spawnratePerSeconds;

        for (int i = 0; i < StartingRatAmount; i++)
        {
            SpawnEnemy(ratPrefab);
        }
        hasBeenSpawned = true;
    }

    void Update()
    {
        time = timeScript.GetTime();

        if (time % spawnRate == 0 && !hasBeenSpawned)
        {
            for (int i = 0; i < spawnsRatPerSpawntick; i++)
            {
                SpawnEnemy(ratPrefab);
            }

            for (int i = 0; i < spawnsBatPerSpawntick; i++)
            {
                SpawnEnemy(batPrefab);
            }
            hasBeenSpawned = true;
        }

        if (time % spawnRate == 1)
        {
            hasBeenSpawned = false;
        }

        UpdateSpawnRate();
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
            int nextEnemyPlace = Random.Range(1, 10);

            switch (nextEnemyPlace)
            {
                case 1:
                    Instantiate(enemyPrefab, spawn1.position, spawn1.rotation);
                    break;
                case 2:
                    Instantiate(enemyPrefab, spawn2.position, spawn2.rotation);
                    break;
                case 3:
                    Instantiate(enemyPrefab, spawn3.position, spawn3.rotation);
                    break;
                case 4:
                    Instantiate(enemyPrefab, spawn4.position, spawn4.rotation);
                    break;
                case 5:
                    Instantiate(enemyPrefab, spawn5.position, spawn5.rotation);
                    break;
                case 6:
                    Instantiate(enemyPrefab, spawn6.position, spawn6.rotation);
                    break;
                case 7:
                    Instantiate(enemyPrefab, spawn7.position, spawn7.rotation);
                    break;
                case 8:
                    Instantiate(enemyPrefab, spawn8.position, spawn8.rotation);
                    break;
                case 9:
                    Instantiate(enemyPrefab, spawn9.position, spawn9.rotation);
                    break;
                default:
                    break;
            }
    }

    private void UpdateSpawnRate()
    {
        if (time % increasedSpawnratePerSeconds == 0 && !spawnrateReadjusted)
        {
            spawnrateReadjusted = true;
            if (spawnRate > 1)
            {
                spawnRate--;
            }
            else
            {
                spawnsRatPerSpawntick++;
                spawnRate = spawnratePerSeconds;

                if (spawnsBatPerSpawntick != 0)
                {
                    spawnsBatPerSpawntick++;
                }
            }

            if (spawnsRatPerSpawntick == 5 && spawnsBatPerSpawntick == 0)
            {
                spawnsRatPerSpawntick--;
                spawnsRatPerSpawntick++;
            }
        }
        else if (time % increasedSpawnratePerSeconds == 1)
        {
            spawnrateReadjusted = false;
        }
    }
}
