using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private bool pause;
    public bool gameOver;
    public GameObject button;
    public GameObject scoreButton;
    void Start(){
        button.SetActive(false);
        scoreButton.SetActive(false);
    }
    public void EndGame(){
        if(!gameOver){
            gameOver = true;
            Time.timeScale = 0f;
            button.SetActive(true);
            scoreButton.SetActive(true);
        }
    }
    public void Restart(){
        SceneManager.LoadScene(0);
    }
}
