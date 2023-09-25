using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern{
    public class ObjectBehaviour : Subject{
        public GameObject obstical;
        private FlashingPanel flashPanel;
        private Vector3 pos;
        private float rand;
        private float min;
        private float max;
        private float count = 1.0f;
        private float scaler = 0.0f;
        private float fireRate = 4.0f;
        private float nextFire = 0.0f;
        private gameManager gameManager;
        public int[] posForX;
        private float lastPosX;
        void Start(){
            pos.y = 1;
            pos.z = 74;
            //min = -8.3f;
            //max = 8.3f;
            gameManager = FindObjectOfType<gameManager>();
            flashPanel = GameObject.Find("Canvas").GetComponent<FlashingPanel>();
            if(flashPanel){
                Attach(flashPanel);
            }
        }

        void OnDisable(){
            if(flashPanel){
                Detach(flashPanel);
            }
        }
        void FixedUpdate(){
            if(Time.timeSinceLevelLoad>nextFire&&!gameManager.gameOver){
                NotifyObservers();
                nextFire = Time.timeSinceLevelLoad + (fireRate/count);
                pos.x = posForX[Random.Range(0, 5)];
                while(pos.x == lastPosX){
                    pos.x = posForX[Random.Range(0,4)];
                }
                lastPosX = pos.x;
                Debug.Log(pos.x);
                GameObject newob = Instantiate(obstical, pos, obstical.transform.rotation);
                scaler++;
                if(count<10&&scaler % 3 == 0){count++;}
            }
        }
    }
}