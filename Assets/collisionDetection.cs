using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    public bool playerIsHit;
    private void OnTriggerEnter2D()
    {
        Debug.Log("hit!");
        playerIsHit = true;
    }
    private void OnTriggerExit2D()
    {
        playerIsHit = false;
    }
}
