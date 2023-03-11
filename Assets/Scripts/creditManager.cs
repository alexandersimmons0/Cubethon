using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class creditManager : MonoBehaviour
{
    void Update()
    {
        if(Time.timeSinceLevelLoad>=3){
            SceneManager.LoadScene("Menu");
        }
        
    }
}
