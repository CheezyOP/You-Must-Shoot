using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time < 60)
        {
            GetComponent<Text>().text = "Time: " + Mathf.RoundToInt(time).ToString() + "s";
        }
        else
        {
            GetComponent<Text>().text = "Time: " + Mathf.FloorToInt(time / 60).ToString() + "m " + Mathf.RoundToInt(time % 60).ToString() + "s";
        }
    }

    public int GetTime()
    {
        return Mathf.RoundToInt(time);
    }
}
