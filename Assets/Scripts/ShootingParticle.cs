using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
//shooting module

public class ShootingParticle : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator m_Anim;
    public GameObject bullet;
    private float bulletSpeed = 1000f;
    [SerializeField] float time;
    [SerializeField] float timer = 10f;
    PlatformerCharacter2D platformerCharacter2D;
    void Awake()
    {
        time = 0f;
        m_Anim = GetComponent<Animator>();
        platformerCharacter2D = GetComponent<PlatformerCharacter2D>();
        
    }

    private void Update()
    {
        BulletCheckSequence();
    }

    private void BulletCheckSequence()
    {
        if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Pew"))//to check if player is firing
        {
            time += Time.deltaTime;
            if (time < 0.02f)
            {
                FireBullet();
            }

        }
        else
        {
            time = 0f;
        } 
    }

    private void FireBullet()
    {
        //Clone of the bullet
        GameObject Clone;

        //spawning the bullet at position
        Clone = (Instantiate(bullet, transform.position, transform.rotation)) as GameObject;
        Physics2D.IgnoreCollision(Clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());


        //check where player is facing
        CheckPlayerDirection(Clone);
        //destroy the bullets after they are shot
        Destroy(Clone, 2f);
        Debug.Log("Force is added");
    }

    private void CheckPlayerDirection(GameObject Clone)
    {
        if(platformerCharacter2D.m_FacingRight)
        {
            Clone.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
        }
        else
        {
            Clone.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed);
        }
        
    }
}
