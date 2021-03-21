using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;

    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    private bool dead = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("PF Player").transform;
    }

    void Update()
    {
        if (!dead)
        {
            Vector3 direction = player.position - transform.position;
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            MoveCharacter(movement);
        }
    }

    /// <summary>
    /// Determines direction of enemy, and calls the movement function
    /// Usually Vector3 could be normalised, this caused me some errors though
    /// To fix this issue I squered the direction based one certain condition, as to not make the enemy unfairly fast
    /// This does cause the enemy to move faster when further away, or slower when close to player
    /// </summary>
    /// <param name="direction">Direction of current enemy</param>
    void MoveCharacter(Vector2 direction)
    {
        if (!dead)
        {
            /// Format direction as to make movement speed fair and direction correct
            if (direction.x > 0)
            {
                direction.x = Mathf.Sqrt(Mathf.Sqrt(direction.x));
            } 
            else
            {
                direction.x = Mathf.Sqrt(Mathf.Sqrt(Mathf.Abs(direction.x))) * -1;
            }

            if (direction.y > 0)
            {
                direction.y = Mathf.Sqrt(Mathf.Sqrt(direction.y));
            }
            else
            {
                direction.y = Mathf.Sqrt(Mathf.Sqrt(Mathf.Abs(direction.y))) * -1;
            }

            /// Move enemy
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

            /// Flip enemy sprite if needed
            if (direction.x > 0.3)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public void KillThis()
    {
        dead = true;
    }
}
