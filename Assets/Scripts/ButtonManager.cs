using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject muteButton;
    public GameObject image;
    public bool mute = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMute();
        }
    }

    /// <summary>
    /// Toggles main theme, along with the stripe that goes through the image
    /// </summary>
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

    /// <summary>
    /// Loads new scene based on given argument
    /// </summary>
    /// <param name="newGameLevel">Name of the scene which needs to be switched</param>
    public void BtnRedirect(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
