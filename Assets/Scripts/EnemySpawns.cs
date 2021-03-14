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
    public TimeScript timeScript;

    private float time;

    public int increasedSpawnratePerSeconds;
    public double spawnratePerSeconds;
    public int StartingRatAmount;

    private bool hasBeenSpawned;
    private bool spawnrateReadjusted;

    void Start()
    {
        time = timeScript.GetAccurateTime();
        hasBeenSpawned = false;
        spawnrateReadjusted = false;

        for (int i = 0; i < StartingRatAmount; i++)
        {
            SpawnRat();
        }
    }

    void Update()
    {
        time = timeScript.GetTime();

        SpawnRat();
        UpdateSpawnRate();
    }

    private void SpawnRat()
    {
        if (time % spawnratePerSeconds == 0 && !hasBeenSpawned)
        {
            int nextRatPlace = Random.Range(1, 10);

            switch (nextRatPlace)
            {
                case 1:
                    Instantiate(ratPrefab, spawn1.position, spawn1.rotation);
                    break;
                case 2:
                    Instantiate(ratPrefab, spawn2.position, spawn2.rotation);
                    break;
                case 3:
                    Instantiate(ratPrefab, spawn3.position, spawn3.rotation);
                    break;
                case 4:
                    Instantiate(ratPrefab, spawn4.position, spawn4.rotation);
                    break;
                case 5:
                    Instantiate(ratPrefab, spawn5.position, spawn5.rotation);
                    break;
                case 6:
                    Instantiate(ratPrefab, spawn6.position, spawn6.rotation);
                    break;
                case 7:
                    Instantiate(ratPrefab, spawn7.position, spawn7.rotation);
                    break;
                case 8:
                    Instantiate(ratPrefab, spawn8.position, spawn8.rotation);
                    break;
                case 9:
                    Instantiate(ratPrefab, spawn9.position, spawn9.rotation);
                    break;
                default:
                    break;
            }

            hasBeenSpawned = true;
        }
        else if (time % spawnratePerSeconds == 1)
        {
            hasBeenSpawned = false;
        }
    }

    private void UpdateSpawnRate()
    {
        if (time % increasedSpawnratePerSeconds == 0 && !spawnrateReadjusted)
        {
            spawnrateReadjusted = true;
            if (spawnratePerSeconds >= 1)
            {
                spawnratePerSeconds--;
            }
            else if (spawnratePerSeconds <= 1 && spawnratePerSeconds > 0.1)
            {
                spawnratePerSeconds -= 0.1;
            }
        }
        else if (time % increasedSpawnratePerSeconds == 1)
        {
            spawnrateReadjusted = false;
        }
    }
}
