using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
   [SerializeField] int health;
    AudioSource aud;
    ReloadScene reload;
    void Damage()
    {
        if (gameObject.tag == "Player")
        {
            CheckIfAttacking();
        }
        else
        {
            health--;
        }
    }

    private void CheckIfAttacking()
    {
        Animator m_Anim = gameObject.GetComponent<Animator>();
        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Pow"))
        {
            health--;
        }
    }
    private void Awake()
    {
        reload = GetComponent<ReloadScene>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            if (gameObject.tag != "Player")
            {
                PlayDeathSound();
                Invoke("KillEnemy", 0.5f);
            }
            if (gameObject.tag == "Player")
            {
                reload.LoadScene();
            }
        }
    }

    private void KillEnemy()
    {
        gameObject.SetActive(false);
    }

    private void PlayDeathSound()
    {
        aud = GetComponent<AudioSource>();
        aud.enabled = true;
        if (!aud.isPlaying)
        {
            aud.Play();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(gameObject.tag);
        print(collision.gameObject.tag);
        if (gameObject.tag == "Enemy" && collision.gameObject.tag == "Player")
            Damage();
        if (gameObject.tag == "Player")
            if (collision.gameObject.tag == "Enemy")
                Damage();
    }

}
