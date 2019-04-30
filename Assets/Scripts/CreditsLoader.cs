using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsLoader : MonoBehaviour
{
    AudioSource aud;
    Scene scene;
    int sceneIndex;
    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex;
        aud = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        aud.enabled = true;
        if(!aud.isPlaying)
        {
            aud.Play();
        }
        Invoke("LoadCredits", 2f);
    }
    void LoadCredits()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        aud.enabled = false;
    }
}
