using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatHit : MonoBehaviour
{
    public EnemyMovement movementScript;
    private KillCounter kills;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        kills = GameObject.FindGameObjectWithTag("KillCounter").GetComponent<KillCounter>();
    }

    public void HitRat()
    {
        movementScript.KillThis();
        anim.Play("Rat_Death");
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<PolygonCollider2D>());
        kills.addKill();
    }
}
