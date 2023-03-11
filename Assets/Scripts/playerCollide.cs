using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollide : MonoBehaviour
{
    public playerMovement move;
    void OnCollisionEnter(Collision collider){
        if(collider.collider.tag == "ob"){
           // Time.timeScale = 0f;
        }
    }
}
