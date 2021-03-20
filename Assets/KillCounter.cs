using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    private int kills;
    private Text killsText;
    // Start is called before the first frame update
    void Start()
    {
        kills = 0;
        killsText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void addKill()
    {
        kills++;
        killsText.text = kills.ToString();
    }
}
