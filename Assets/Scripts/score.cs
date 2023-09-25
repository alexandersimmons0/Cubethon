using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverPattern{
    public class score : Subject{
        public float count;
        private float nextFire;
        private float fireRate = 0.5f;
        public Text scoreText;
        public bool changeColor{get; private set;}
        public bool railSetting{get; set;}
        public PlayerColour colour;
        private gameManager game;

        void OnEnable(){
            changeColor = false;
            railSetting = false;
            colour = GameObject.Find("player").GetComponent<PlayerColour>();
            if(colour){
                Attach(colour);
            }
            game = GameObject.Find("gameManager").GetComponent<gameManager>();
            if(game){
                Attach(game);
            }
        }

        void OnDisable(){
            if(colour){
                Detach(colour);
            }
            if(game){
                Detach(game);
            }
        }
        void FixedUpdate(){
            if(Time.timeSinceLevelLoad>nextFire){
                nextFire = Time.timeSinceLevelLoad + fireRate;
                count += 10;
                changeColor = false;
                //railSetting = false;
            }
            if(count % 100 == 0.0 && !changeColor && count != 0){
                changeColor = true;
                NotifyObservers();
            }
            scoreText.text = count.ToString();
        }
    }
}