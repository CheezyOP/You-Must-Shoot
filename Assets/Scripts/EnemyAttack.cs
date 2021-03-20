using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public string animationName;

    private LivesManager playerLives;
    private Animator anim;

    private TimeScript timeScript;
    private int time;
    private int previousTime;

    // Start is called before the first frame update
    void Start()
    {
        previousTime = 0;
        anim = GetComponent<Animator>();
        playerLives = GameObject.FindGameObjectWithTag("PF Player").GetComponent<LivesManager>();
        timeScript = GameObject.FindGameObjectWithTag("Time").GetComponent<TimeScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        time = timeScript.GetTime();
        if (time - previousTime > 2)
        {
            time = timeScript.GetTime();
            if (collision.gameObject.name.Contains("Player"))
            {
                anim.Play(animationName);
                playerLives.LoseLife();
                previousTime = time;
            }
        }
    }
}
