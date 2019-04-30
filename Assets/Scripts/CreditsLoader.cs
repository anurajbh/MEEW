using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsLoader : MonoBehaviour
{
    AudioSource aud;
    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        aud.enabled = true;
        if(!aud.isPlaying)
        {
            aud.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        aud.enabled = false;
    }
}
