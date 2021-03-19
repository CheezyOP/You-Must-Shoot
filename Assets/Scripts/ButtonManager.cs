using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject muteButton;
    public GameObject image;
    public bool mute = false;

    public void BtnRedirect(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMute();
        }
    }

    public void ToggleMute()
    {
        Image stripe = image.GetComponent<Image>();

        if (muteButton.GetComponent<AudioSource>().mute)
        {
            stripe.color = new Color(stripe.color.r, stripe.color.g, stripe.color.b, 0);
        }
        else
        {
            stripe.color = new Color(stripe.color.r, stripe.color.g, stripe.color.b, 1);
        }
        muteButton.GetComponent<AudioSource>().mute = !muteButton.GetComponent<AudioSource>().mute;
        mute = !mute;
    }
}
