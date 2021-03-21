using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        public float movementSpeedUpgradeIncrease;
        public float throwSpeedUpgradeIncrease;

        public Camera cam;
        private Animator animator;
        public AudioClip upgradeSound;

        public Text movementSpeedText;
        public Image movementSpeedIcon;
        public Text movementSpeedCounterText;
        private int movementSpeedCounter;

        public Text throwSpeedText;
        public Image throwSpeedIcon;
        public Text throwSpeedCounterText;
        private int throwSpeedCounter;

        public Text shrinkText;
        public Image shrinkIcon;

        private bool activatedCheats;

        public LivesManager livesManager;
        public Shooting shotScript;

        //Vector2 mousePos;

        private void Start()
        {
            animator = GetComponent<Animator>();
            activatedCheats = false;
            movementSpeedCounter = 0;
            throwSpeedCounter = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (!activatedCheats)
                {
                    livesManager.ToggleInvincibility();
                    shotScript.SetStoneAmount(999);

                    getMovementSpeedUpgrade();
                    getShrinkUpgrade();
                    getThrowSpeedUpgrade();
                    activatedCheats = true;
                }
                else
                {
                    activatedCheats = false;
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
                HandleUpgradePickup(collision);
                getMovementSpeedUpgrade();
            }
            else if (collision.gameObject.name.Contains("ThrowSpeed"))
            {
                HandleUpgradePickup(collision);
                getThrowSpeedUpgrade();
            }
            else if (collision.gameObject.name.Contains("Shrink"))
            {
                HandleUpgradePickup(collision);
                getShrinkUpgrade();
            }
        }

        private void HandleUpgradePickup(Collision2D collision)
        {
            GetComponent<AudioSource>().clip = upgradeSound;
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }

        private void getMovementSpeedUpgrade()
        {
            if (movementSpeedCounter == 0)
            {
                movementSpeedText.color = new Color(movementSpeedText.color.r, movementSpeedText.color.g, movementSpeedText.color.b, 255);
                movementSpeedIcon.color = new Color(movementSpeedIcon.color.r, movementSpeedIcon.color.g, movementSpeedIcon.color.b, 255);
                movementSpeedCounterText.color = new Color(movementSpeedCounterText.color.r, movementSpeedCounterText.color.g, movementSpeedCounterText.color.b, 255);

                speed += movementSpeedUpgradeIncrease;
                movementSpeedCounter++;
            }
            else if (movementSpeedCounter < 10)
            {
                speed += movementSpeedUpgradeIncrease;
                movementSpeedCounter++;

                if (movementSpeedCounter == 7)
                {
                    movementSpeedCounterText.color = new Color(255 , 140, 0, 255);
                }
                else if (movementSpeedCounter == 10)
                {
                    movementSpeedCounterText.color = new Color(255, 0, 0, 255);
                }
            }

            movementSpeedCounterText.text = movementSpeedCounter.ToString() + 'x';
        }

        private void getThrowSpeedUpgrade()
        {
            if (throwSpeedCounter == 0)
            {
                throwSpeedText.color = new Color(throwSpeedText.color.r, throwSpeedText.color.g, throwSpeedText.color.b, 255);
                throwSpeedIcon.color = new Color(throwSpeedIcon.color.r, throwSpeedIcon.color.g, throwSpeedIcon.color.b, 255);
                throwSpeedCounterText.color = new Color(throwSpeedCounterText.color.r, throwSpeedCounterText.color.g, throwSpeedCounterText.color.b, 255);

                throwSpeedCounter++;
                shotScript.IncreaseBulletForce(throwSpeedUpgradeIncrease);
            }
            else if (throwSpeedCounter < 20)
            {
                throwSpeedCounter++;
                shotScript.IncreaseBulletForce(throwSpeedUpgradeIncrease);

                if (throwSpeedCounter == 15)
                {
                    throwSpeedCounterText.color = new Color(255, 140, 0, 255);
                }
                else if (throwSpeedCounter == 20)
                {
                    throwSpeedCounterText.color = new Color(255, 0, 0, 255);
                }
            }

            throwSpeedCounterText.text = throwSpeedCounter.ToString() + 'x';
        }

        private void getShrinkUpgrade()
        {
            transform.localScale = new Vector3((float)0.8, (float)0.8, 1);
            shrinkText.color = new Color(shrinkText.color.r, shrinkText.color.g, shrinkText.color.b, 255);
            shrinkIcon.color = new Color(shrinkIcon.color.r, shrinkIcon.color.g, shrinkIcon.color.b, 255);
        }
    }
}
