using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSound : StateMachineBehaviour
{
    [SerializeField] AudioClip aud;
    AudioSource audSource;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        audSource = animator.GetComponent<AudioSource>();
        audSource.enabled = true;
        audSource.clip = aud;
        if(!audSource.isPlaying)
        {
            audSource.Play();
        }
            
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audSource.Pause();
        audSource.enabled = false;
    }
}
