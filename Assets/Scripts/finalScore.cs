using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalScore : MonoBehaviour
{
    private string score;
    public Text count;
    public Text finalS;
    void OnEnable(){
        finalS.text = count.text;
    }
}
