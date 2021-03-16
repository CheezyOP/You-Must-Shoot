using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePointUp;
    public Transform firePointRight;
    public Transform firePointDown;
    public Transform firePointLeft;

    public GameObject bulletPrefab;

    private float bulletForce = 10f;

    public Text amountOfStonesTxt;
    public int amountOfStones;

    // Update is called once per frame
    void Update()
    {
        if (amountOfStones > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Shoot(0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Shoot(1);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Shoot(2);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Shoot(3);
            }
        }
    }

    void Shoot(int fireDirection)
    {
        ///Decides rotation
        Vector3 EulerAngleVelocity = new Vector3(0, 100, 0);
        Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * Time.deltaTime);

        if (fireDirection == 0 && transform.position.y < -9.2)
        {
            ThrowStone();

            GameObject bullet = Instantiate(bulletPrefab, firePointUp.position, firePointUp.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.MoveRotation(deltaRotation);
            rb.AddForce(firePointUp.up * bulletForce, ForceMode2D.Impulse);
        }
        else if (fireDirection == 1 && transform.position.x < -7.7)
        {
            ThrowStone();

            GameObject bullet = Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePointRight.right * bulletForce, ForceMode2D.Impulse);
        }
        else if (fireDirection == 2 && transform.position.y > -50.2)
        {
            ThrowStone();

            GameObject bullet = Instantiate(bulletPrefab, firePointDown.position, firePointDown.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-firePointDown.up * bulletForce, ForceMode2D.Impulse);
        }
        else if (fireDirection == 3 && transform.position.x > -52.5)
        {
            ThrowStone();

            GameObject bullet = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-firePointLeft.right * bulletForce, ForceMode2D.Impulse);
        }
    }

    public void IncreaseBulletForce(float bulletForce)
    {
        this.bulletForce += bulletForce;
    }

    public void SetStoneAmount(int amountOfStones)
    {
        this.amountOfStones = amountOfStones;
        amountOfStonesTxt.text = amountOfStones.ToString();
    }

    public void AddStone()
    {
        this.amountOfStones++; 
        amountOfStonesTxt.text = amountOfStones.ToString();
    }

    private void ThrowStone()
    {
        this.amountOfStones--; 
        amountOfStonesTxt.text = amountOfStones.ToString();
    }
}
