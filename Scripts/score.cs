using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public float count;
    private float nextFire;
    private float fireRate = 0.5f;
    public Text scoreText;
    void FixedUpdate(){
        if(Time.timeSinceLevelLoad>nextFire){
            nextFire = Time.timeSinceLevelLoad + fireRate;
            count += 10;
            Debug.Log("counting");
        }
        scoreText.text = count.ToString();
        Debug.Log("updated");
    }
}
