using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ObserverPattern{
    public class gameManager : Observer
    {
        private playerMovement _player;
        private bool pause;
        public bool gameOver;
        public GameObject button;
        public GameObject scoreButton;
        public GameObject screen;
        private score scoreCount;

        void Start(){
            button.SetActive(false);
            scoreButton.SetActive(false);
            screen.SetActive(false);
        }

        public void EndGame(){
            if(!gameOver){
                gameOver = true;
            //   Time.timeScale = 0f;
                button.SetActive(true);
                scoreButton.SetActive(true);
                screen.SetActive(true);
            }
        }
        public void Restart(){
            SceneManager.LoadScene("Level");
        }

        public override void Notify(Subject subject){
            if(!_player){
                _player = subject.GetComponent<playerMovement>();
            }
            if(_player && _player.IsDead){
                EndGame();
            }
        }
    }
}