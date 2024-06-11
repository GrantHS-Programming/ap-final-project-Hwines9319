using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ccBossAI : StateMachineBehaviour
{
   private int rand;
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0,2);

        if (rand == 0){
            animator.SetTrigger("BossAttack");

        }
        else{
            animator.SetTrigger("BossMove"); 
        }
        animator.ResetTrigger("BossAppear");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("BossAttack");
        animator.ResetTrigger("BossMove");

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
