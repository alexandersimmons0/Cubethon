using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public GameObject cam;
    public Vector3 offset;
    float smooth = 5.0f;
    private float tiltAngle = -5f;
    void Update()
    {
        transform.position = player.position + offset;
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
    }
}
