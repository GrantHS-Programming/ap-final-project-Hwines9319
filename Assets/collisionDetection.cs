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

    void Start()
    {
       bossMaxHealth = bossHealth;
    }
    void Update()
    {
        ccHealthBar.fillAmount = Mathf.Clamp(bossHealth / bossMaxHealth, 0, 1);
    }
    public void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {   
        if (collision.tag == "help")
        {
            Debug.Log("is a thing?");
            bossHealth -= ccdamage;
        }
    }  
}
    
