using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip ChestSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.Equals("PF Player"))
        //{
            //audioSource = GetComponent<"Key Jiggle.wav">();
            //audioSource.clip = ChestSound;
            //audioSource.Play();
        //}
    }
}
