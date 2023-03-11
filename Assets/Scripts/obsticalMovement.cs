using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsticalMovement : MonoBehaviour
{
    private float speed = 200f;
    private float time;
    private gameManager gameManager;
    private Rigidbody _rb;
    void Start(){
        _rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<gameManager>();
    }
    void Update(){
        time = Time.timeSinceLevelLoad;
        if(this.transform.position.z>-5&&!gameManager.gameOver){
            this.transform.position = this.transform.position - this.transform.forward * (time/speed);
        }else if(this.transform.position.z<=-5){
            Destroy(this.gameObject);
        }
    }
}
