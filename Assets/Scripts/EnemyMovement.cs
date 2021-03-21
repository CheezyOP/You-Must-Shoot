using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("PF Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            Vector3 direction = player.position - transform.position;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            //direction.Normalize();
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

    void MoveCharacter(Vector2 direction)
    {
        if (!dead)
        {
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

            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

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
