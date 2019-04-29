using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheck : MonoBehaviour
{
    ReloadScene reload;
    AudioSource aud;
    private void Awake()
    {
        reload = GetComponent<ReloadScene>();
        aud = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!aud.isPlaying)
        {
            aud.Play();
        }
        Invoke("Restart", 0.5f);
    }

    private void Restart()
    {
        reload.LoadScene();
    }
}
