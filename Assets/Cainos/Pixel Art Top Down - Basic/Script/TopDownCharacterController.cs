using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        public Camera cam;
        private Animator animator;

        public Text movementSpeedText;
        public Image movementSpeedIcon;
        public Text throwSpeedText;
        public Image throwSpeedIcon;
        public Text shrinkText;
        public Image shrinkIcon;

        private int lives;
        private bool takesDamage;


        public Shooting shotScript;

        //Vector2 mousePos;

        private void Start()
        {
            animator = GetComponent<Animator>();
            lives = 3;
            takesDamage = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (takesDamage)
                {
                    takesDamage = false;
                    shotScript.SetStoneAmount(999);

                    getMovementSpeedUpgrade();
                    getShrinkUpgrade();
                    getThrowSpeedUpgrade();
                }
                else
                {
                    takesDamage = true;
                }
            }

            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;

            //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            //Input.mousePosition
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains("MovementSpeed"))
            {
                Destroy(collision.gameObject);
                getMovementSpeedUpgrade();
            }
            else if (collision.gameObject.name.Contains("ThrowSpeed"))
            {
                Destroy(collision.gameObject);
                getThrowSpeedUpgrade();
            }
            else if (collision.gameObject.name.Contains("Shrink"))
            {
                Destroy(collision.gameObject);
                getShrinkUpgrade();
            }
        }

        private void getMovementSpeedUpgrade()
        {
            speed += 1;
            movementSpeedText.color = new Color(movementSpeedText.color.r, movementSpeedText.color.g, movementSpeedText.color.b, 255);
            movementSpeedIcon.color = new Color(movementSpeedIcon.color.r, movementSpeedIcon.color.g, movementSpeedIcon.color.b, 255);
        }

        private void getThrowSpeedUpgrade()
        {
            shotScript.IncreaseBulletForce(3);
            throwSpeedText.color = new Color(throwSpeedText.color.r, throwSpeedText.color.g, throwSpeedText.color.b, 255);
            throwSpeedIcon.color = new Color(throwSpeedIcon.color.r, throwSpeedIcon.color.g, throwSpeedIcon.color.b, 255);
        }

        private void getShrinkUpgrade()
        {
            transform.localScale = new Vector3((float)0.8, (float)0.8, 1);
            shrinkText.color = new Color(shrinkText.color.r, shrinkText.color.g, shrinkText.color.b, 255);
            shrinkIcon.color = new Color(shrinkIcon.color.r, shrinkIcon.color.g, shrinkIcon.color.b, 255);
        }
    }
}
