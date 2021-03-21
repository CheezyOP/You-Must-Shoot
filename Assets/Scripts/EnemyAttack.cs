using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public string animationName;
    public int attackCoolDown;

    private LivesManager playerLives;
    private Animator anim;

    private TimeScript timeScript;
    private int collisionTime;
    private int time;
    private int previousTime;

    private bool needsToLoseLife;

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
        /// Done this in order to time the attack animation with the hurt sound
        time = timeScript.GetTime();
        if (time - previousTime == 1 && needsToLoseLife)
        {
            playerLives.LoseLife();
            needsToLoseLife = false;
        }
    }

    /// <summary>
    /// Used to attack player
    /// </summary>
    /// <param name="collision">Collision, of which player and enemy could be extracted</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            collisionTime = timeScript.GetTime();
            if (collisionTime - previousTime > attackCoolDown)
            {
                anim.Play(animationName);
                previousTime = collisionTime;
                needsToLoseLife = true;
            }
        }
    }
}
