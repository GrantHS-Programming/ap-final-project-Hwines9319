using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    public float damage;
    public BoxCollider2D c;
    

    // Start is called before the first frame update
    void Start()
    {
       maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }
    public void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {   
        if (collision.gameObject.name == "hitCheckerClaw")
        {
            health -= damage;
        }
    }  
}
