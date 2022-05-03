using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public Transform player;
    

    public Vector3 offsetVector;
    public float slerpSpeed = 2f;
    void Update()
    {
        Vector3 offsetRotated = player.transform.rotation * offsetVector;
        transform.position = player.transform.position + offsetRotated;
        transform.rotation = Quaternion.Slerp (transform.rotation, player.rotation, Time.deltaTime* slerpSpeed);
    }
}
