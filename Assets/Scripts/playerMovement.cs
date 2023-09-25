using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ObserverPattern{
    public class playerMovement : Subject{
        private float hInput;
        //private bool isDead = false;
        private Rigidbody _rb;
        private float speed = 10f;
        private float disToGround;
        private gameManager _gameManager;

        public bool IsDead{get; private set;}

        void Start(){
            IsDead = false;
            _rb = GetComponent<Rigidbody>(); 
            disToGround = GetComponent<BoxCollider>().bounds.extents.y;
            Time.timeScale = 1f;
        }

        void OnEnable(){
            _gameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
            Debug.Log(_gameManager);
            if(_gameManager){
                Attach(_gameManager);
                Debug.Log("game manager attached");
            }
        }

        void OnDisable(){
            if(_gameManager){
                Detach(_gameManager);
            }
        }

        void Update(){
            hInput = Input.GetAxis("Horizontal") * speed;
        }

        void FixedUpdate(){
            _rb.MovePosition(this.transform.position + this.transform.right * hInput * Time.fixedDeltaTime);
            if(transform.position.y<=0.5 && !IsDead){
                //FindObjectOfType<gameManager>().EndGame();
                Die();
            }
        }

        private bool IsGrounded(){
            return Physics.Raycast(transform.position, -Vector3.up, disToGround + 0.1f);
        }

        void OnCollisionEnter(Collision collider){
            if(collider.collider.tag == "ob"){
                //FindObjectOfType<gameManager>().EndGame();
                Die();
            }
        }

        void Die(){
            IsDead = true;
            Debug.Log("died");
            NotifyObservers();
        }
    }
}