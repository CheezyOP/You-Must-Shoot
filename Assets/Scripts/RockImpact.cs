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
        if (true)
        {
            CheckCurrentCollisionSound(collision);
        }
    }

    /// <summary>
    /// Checks which sound needs to be played for each rock collision, and calls corresponding methods for playing the sounds
    /// </summary>
    /// <param name="collision">Collisions which the rock causes</param>
    private void CheckCurrentCollisionSound(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Wall"))
        {
            PlayWallCollisionSound();
        }
        else if (collision.gameObject.name.Contains("Stone"))
        {
            PlayStoneCollisionSound();
        }
        else if (collision.gameObject.name.Contains("Pot"))
        {
            PlayPotSound();
        }
        /// Rocks only make sound if they hit hard enough
        else if ((collision.gameObject.name.Contains("PixelRock") && gameObject.name.Contains("PixelRock")) &&
        (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) >= 0.4))
        {
            /// Used to prevent errors if rocks got deleted faster then when the sound got played
            if (collision.gameObject != null) {
                PlayRocksCollisionSound();
            }
        }
        /// Enemies only make sound if they get hit hard enough
        else if (gameObject.name.Contains("PixelRock") && (collision.gameObject.name.Contains("Rat") || collision.gameObject.name.Contains("Bat")) &&
            Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) >= 2.0)
        {
            PlayBatOrRatCollisionSound(collision);
        }
    }

    private void PlayWallCollisionSound()
    {
        GetComponent<AudioSource>().clip = collisionSoundRockWall;
        GetComponent<AudioSource>().pitch = 1;
        GetComponent<AudioSource>().Play();
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
    }

    private void PlayStoneCollisionSound()
    {
        GetComponent<AudioSource>().clip = collisionSoundRocksTouch;
        GetComponent<AudioSource>().pitch = Random.Range((float)0.6, (float)1.4);
        GetComponent<AudioSource>().Play();
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
    }

    private void PlayPotSound()
    {
        GetComponent<AudioSource>().clip = collisionSoundRockPot;
        GetComponent<AudioSource>().pitch = Random.Range((float)0.6, (float)1.4);
        GetComponent<AudioSource>().Play();
    }

    private void PlayRocksCollisionSound()
    {
        GetComponent<AudioSource>().clip = collisionSoundRocksTouch;
        GetComponent<AudioSource>().pitch = Random.Range((float)0.6, (float)1.4);
        GetComponent<AudioSource>().Play();
    }

    private void PlayBatOrRatCollisionSound(Collision2D collision)
    {
        /// Determine enemy type
        if (collision.gameObject.name.Contains("Bat"))
        {
            collision.gameObject.GetComponent<BatHit>().HitBat();
        }
        else
        {
            collision.gameObject.GetComponent<RatHit>().HitRat();
        }

        /// Chooses a random enemy sound
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