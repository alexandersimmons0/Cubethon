using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    private float hInput;
    private Rigidbody _rb;
    private float speed = 10f;
    private float disToGround;
    void Start()
    {
        _rb = GetComponent<Rigidbody>(); 
        disToGround = GetComponent<BoxCollider>().bounds.extents.y;
        Time.timeScale=1f;
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal") * speed;
    }
    void FixedUpdate(){
        _rb.MovePosition(this.transform.position + this.transform.right * hInput * Time.fixedDeltaTime);
    }
    private bool IsGrounded(){
        return Physics.Raycast(transform.position, -Vector3.up, disToGround + 0.1f);
    }
    void OnCollisionEnter(Collision collider){
        if(collider.collider.tag == "ob"){
            FindObjectOfType<gameManager>().EndGame();
        }
    }
}
