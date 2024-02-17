using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSplash : MonoBehaviour
{
    AudioSource LavaSplashAudio;
    // Start is called before the first frame update
    void Start()
    {
        LavaSplashAudio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            LavaSplashAudio.Play();
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            LavaSplashAudio.Play();
        }
    }
}