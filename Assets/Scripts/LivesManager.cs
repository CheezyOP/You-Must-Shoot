using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Image heartImage1;
    public Image heartImage2;
    public Image heartImage3;

    private int lives;
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
            if (lives == 2 && heartImage3.color.a == 255)
            {
                heartImage3.color = new Color(heartImage3.color.r, heartImage3.color.g, heartImage3.color.b, 0);
            }
            else if (lives == 1 && heartImage2.color.a == 255)
            {
                heartImage2.color = new Color(heartImage2.color.r, heartImage2.color.g, heartImage2.color.b, 0);
            }
            else if (lives == 0)
            {
                //TODO Deathscreen
            }
        }
    }

    public void ToggleInvincibility()
    {
        isInvincible = !isInvincible;
    }
}
