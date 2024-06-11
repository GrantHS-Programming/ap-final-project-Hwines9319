using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class collisionDetection : MonoBehaviour{
    public float bossHealth;
    public float bossMaxHealth;  
    public UnityEngine.UI.Image ccHealthBar;
    public float ccdamage;
    public BoxCollider2D bc2d1;
    public BoxCollider2D bc2d2;
    public PlayerScript script;
    public Animator animator;

    void Start()
    {
       bossMaxHealth = bossHealth;
    }
    void Update()
    {
        ccHealthBar.fillAmount = Mathf.Clamp(bossHealth / bossMaxHealth, 0, 1);
        if (bossHealth <= 0)
        {
            DestroyGameObject();
        }
    } 
    void FixedUpdate()
    {
        if (bc2d1.bounds.Intersects(bc2d2.bounds))
        {   
            if (script.isAttacking == true && animator.GetBool("BossAttack") != true)
            {
                bossHealth -= ccdamage;
            }
        }
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
    
