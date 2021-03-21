using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatHit : MonoBehaviour
{
    public EnemyMovement movementScript;
    private KillCounter kills;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        kills = GameObject.FindGameObjectWithTag("KillCounter").GetComponent<KillCounter>();
    }

    public void HitBat()
    {
        movementScript.KillThis();
        anim.Play("Bat_Death");

        /// Used to stop sprite from moving and colliding
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<PolygonCollider2D>());
        kills.addKill();
    }
}
