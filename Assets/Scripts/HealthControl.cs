using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    [SerializeField] int health;

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

    private void Update()
    {
        if (health <= 0)
        {
            if (gameObject.tag != "Player")
            {
                gameObject.SetActive(false);
            }
            if (gameObject.tag == "Player")
            {
                print("we need to restart level here");
                //to-do Restart
            }
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
    private void OnParticleCollision(GameObject other)
    {
        print("Collided");
        Damage();
    }

}
