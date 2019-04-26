using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
//shooting module
[RequireComponent(typeof(Platformer2DUserControl))]
public class ShootingParticle : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator m_Anim;
    public GameObject bullet;
    private float bulletSpeed = 1000f;
    //float time;
    //[SerializeField] float timer = 1f;
    void Awake()
    {
        //time = 0f;
        m_Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Pew"))
        {
            //time += Time.deltaTime;
            //if (time >= timer)
            //{
            FireBullet();
            //}     
        }
        //time = 0f;
    }

    private void FireBullet()
    {
        //Clone of the bullet
        GameObject Clone;

        //spawning the bullet at position
        Clone = (Instantiate(bullet, transform.position, transform.rotation)) as GameObject;
        Debug.Log("Bullet is found");


        //add force to the spawned objected
        Clone.GetComponent<Rigidbody2D>().AddForce(transform.right*bulletSpeed);

        Debug.Log("Force is added");
    }
}
