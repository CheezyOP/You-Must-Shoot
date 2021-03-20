using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatHit : MonoBehaviour
{
    public EnemyMovement movementScript;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void HitBat()
    {
        movementScript.KillThis();
        anim.Play("Bat_Death");
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<PolygonCollider2D>());
    }
}
