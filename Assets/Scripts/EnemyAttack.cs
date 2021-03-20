using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public string animationName;

    private LivesManager playerLives;
    private Animator anim;

    private TimeScript timeScript;
    private int collisionTime;
    private int time;
    private int previousTime;
    private bool needsToLoseLife;

    // Start is called before the first frame update
    void Start()
    {
        previousTime = 0;
        collisionTime = 0;
        time = 0;
        needsToLoseLife = false;
        anim = GetComponent<Animator>();
        playerLives = GameObject.FindGameObjectWithTag("PF Player").GetComponent<LivesManager>();
        timeScript = GameObject.FindGameObjectWithTag("Time").GetComponent<TimeScript>();
    }

    private void Update()
    {
        time = timeScript.GetTime();
        if (time - previousTime == 1 && needsToLoseLife)
        {
            playerLives.LoseLife();
            needsToLoseLife = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            collisionTime = timeScript.GetTime();
            if (collisionTime - previousTime > 2)
            {
                anim.Play(animationName);
                previousTime = collisionTime;
                needsToLoseLife = true;
            }
        }
    }
}
