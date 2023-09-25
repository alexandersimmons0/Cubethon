using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern{
    public class FlashingPanel : Observer{
        public GameObject flashPanel;
        private ObjectBehaviour objectBehaviour;

        void Start(){
            flashPanel.SetActive(false);
        }

        public override void Notify(Subject subject){
            if(!objectBehaviour){
                objectBehaviour = subject.GetComponent<ObjectBehaviour>();
            }
            flashPanel.SetActive(true);
            Invoke("Disable", 0.05f);
        }

        void Disable(){
            flashPanel.SetActive(false);
        }
    }
}