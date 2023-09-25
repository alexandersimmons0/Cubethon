using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern{
    public class PlayerColour : Observer{
        private MeshRenderer mesh;
        private score scoreCount;
        private float min = 0.0f;
        private float max = 1.0f;

        void OnEnable(){
            mesh = GetComponent<MeshRenderer>();
        }

        public override void Notify(Subject subject){
            if(!scoreCount){
                scoreCount = subject.GetComponent<score>();
            }
            if(scoreCount && scoreCount.changeColor){
                mesh.material.color = new Color(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max), 1);
            }
        }
    }
}