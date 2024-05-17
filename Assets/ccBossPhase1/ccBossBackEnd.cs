using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossAI : MonoBehaviour
{
    public Animator animator;
    private int rand;

    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("BossIdle", true);
        while(health > 0){
            if (animator.GetBool("BossIdle") == true){
                rand = Random.Range(0,2);
                Debug.Log(rand);

                if (rand == 0){
                    animator.SetBool("BossAttack", true);
                    animator.SetBool("BossAttack", false);
                    Debug.Log("attack");
                    Debug.Log(rand);    
                }
                else{
                    animator.SetBool("BossMove", true);
                    Debug.Log("move");
                    Debug.Log(rand); 
                }
            }
        }
    }
}
