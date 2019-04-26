using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
//shooting module
[RequireComponent(typeof(Platformer2DUserControl))]
public class ShootingParticle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem pewPew;
    private Animator m_Anim;
    [SerializeField] float timer;
    void Awake()
    {
        timer = 0f;
        m_Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        var emission = pewPew.emission;
        if(m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Pew"))
        {
            emission.enabled = true;
        }
        /*there was a delay between the user pressing the button and the actual shooting beginning, so to counter the problem of emission stopping
          instantly, we add a timer to stop it a short while after the user lets go*/ 
        else
        {
            timer += Time.deltaTime;
            if (timer >0.5f)
            {                
                emission.enabled = false;
                timer = 0f;
            }
        }
    }
}
