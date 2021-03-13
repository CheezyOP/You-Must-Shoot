using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;

    public GameObject ratPrefab;
    public TimeScript timeScript;

    public int increasedSpawnratePerSeconds;
    public double spawnratePerSeconds;

    private bool hasBeenSpawned;
    private bool spawnrateReadjusted;

    // Start is called before the first frame update
    void Start()
    {
        hasBeenSpawned = false;
        spawnrateReadjusted = false;
    }

    // Update is called once per frame
    void Update()
    {
        int time = timeScript.GetTime();
        
        if (time % spawnratePerSeconds == 0 && !hasBeenSpawned)
        {
            int nextRatSound = Random.Range(1, 4);

            switch (nextRatSound)
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
                default:
                    break;
            }

            hasBeenSpawned = true;
        }
        else if (time % spawnratePerSeconds == 1)
        {
            hasBeenSpawned = false;
        }
        
        if (time % increasedSpawnratePerSeconds == 0 && !spawnrateReadjusted)
        {
            spawnrateReadjusted = true;
            if (spawnratePerSeconds > 1)
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
