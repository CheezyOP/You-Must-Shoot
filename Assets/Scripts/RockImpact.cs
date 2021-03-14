using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockImpact : MonoBehaviour
{
    public GameObject hitEffect;
    public ButtonManager buttonManager;

    public AudioClip collisionSoundRockWall;
    public AudioClip collisionSoundRocksTouch;
    public AudioClip collisionSoundRockPot;

    public AudioClip ratSound1;
    public AudioClip ratSound2;
    public AudioClip ratSound3;
    public AudioClip ratSound4;
    public AudioClip ratSound5;
    public AudioClip ratSound6;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /// Used to play sounds
        //TODO if (!buttonManager.mute)
        if (true)
        {
            PlayCurrentCollisionSound(collision);
        }
    }

    private void PlayCurrentCollisionSound(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Wall"))
        {
            GetComponent<AudioSource>().clip = collisionSoundRockWall;
            GetComponent<AudioSource>().pitch = 1;
            GetComponent<AudioSource>().Play();
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }
        else if (collision.gameObject.name.Contains("Stone"))
        {
            GetComponent<AudioSource>().clip = collisionSoundRocksTouch;
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().pitch = Random.Range((float)0.6, (float)1.4);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }
        else if ((collision.gameObject.name.Contains("PixelRock") && gameObject.name.Contains("PixelRock")) &&
            (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0.1 || gameObject.GetComponent<Rigidbody2D>().velocity.y > 0.1))
        {
            GetComponent<AudioSource>().clip = collisionSoundRocksTouch;
            GetComponent<AudioSource>().pitch = Random.Range((float)0.6, (float)1.4);
            GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.name.Contains("Pot"))
        {
            GetComponent<AudioSource>().clip = collisionSoundRockPot;
            GetComponent<AudioSource>().pitch = Random.Range((float)0.6, (float)1.4);
            GetComponent<AudioSource>().Play();
        }
        else if (gameObject.name.Contains("PixelRock") && collision.gameObject.name.Contains("Rat") &&
            gameObject.GetComponent<Rigidbody2D>().velocity.x + gameObject.GetComponent<Rigidbody2D>().velocity.y >= 0.8)
        {
            collision.gameObject.GetComponent<RatHit>().HitRat();

            int nextRatSound = Random.Range(1, 7);

            switch (nextRatSound)
            {
                case 1:
                    GetComponent<AudioSource>().clip = ratSound1;
                    break;
                case 2:
                    GetComponent<AudioSource>().clip = ratSound2;
                    break;
                case 3:
                    GetComponent<AudioSource>().clip = ratSound3;
                    break;
                case 4:
                    GetComponent<AudioSource>().clip = ratSound4;
                    break;
                case 5:
                    GetComponent<AudioSource>().clip = ratSound5;
                    break;
                case 6:
                    GetComponent<AudioSource>().clip = ratSound6;
                    break;
                default:
                    break;
            }
            GetComponent<AudioSource>().pitch = Random.Range((float)0.9, (float)1.1);
            GetComponent<AudioSource>().Play();
        }
    }
}