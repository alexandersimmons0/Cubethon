using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverPattern{
    public class restartButton : MonoBehaviour
    {
        public Button button;
        void Start(){
            button.onClick.AddListener(TaskOnClick);
        }
        void TaskOnClick(){
            FindObjectOfType<gameManager>().Restart();
        }
    }
}