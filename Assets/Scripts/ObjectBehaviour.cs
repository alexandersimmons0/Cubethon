using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    public GameObject obstical;
    private Vector3 pos;
    private float rand;
    private float min;
    private float max;
    private float count = 1.0f;
    private float fireRate = 4.0f;
    private float nextFire = 0.0f;
    void Start(){
        pos.y = 1;
        pos.z = 74;
        min = -7.9f;
        max = 7.9f;
    }
    void FixedUpdate(){
        if(Time.time>nextFire){
            nextFire = Time.time + (fireRate/count);
            pos.x = Random.Range(min, max);
            GameObject newob = Instantiate(obstical, pos, obstical.transform.rotation);
            if(count<5){count++;}
        }
    }
}
