using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    private int kills;
    private Text killsText;

    void Start()
    {
        kills = 0;
        killsText = GetComponent<Text>();
    }

    public void addKill()
    {
        kills++;
        killsText.text = kills.ToString();
    }
}
