using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Image heartImage1;
    public Image heartImage2;
    public Image heartImage3;

    public AudioClip meow;
    public int lives;
    private bool isInvincible;

    void Start()
    {
        lives = 3;
        isInvincible = false;
    }

    public void LoseLife()
    {
        if (!isInvincible)
        {
            lives--;
            PlayMeow();

            if (lives == 2)
            {
                heartImage3.color = new Color(heartImage3.color.r, heartImage3.color.g, heartImage3.color.b, 0);
            }
            else if (lives == 1)
            {
                heartImage2.color = new Color(heartImage2.color.r, heartImage2.color.g, heartImage2.color.b, 0);
            }
            else if (lives == 0)
            {
                heartImage1.color = new Color(heartImage1.color.r, heartImage1.color.g, heartImage1.color.b, 0);
                SceneManager.LoadScene("Death screen");
            }
        }
    }

    public void ToggleInvincibility()
    {
        isInvincible = !isInvincible;
    }

    private void PlayMeow()
    {
        GetComponent<AudioSource>().clip = meow;
        GetComponent<AudioSource>().Play();
    }
}
