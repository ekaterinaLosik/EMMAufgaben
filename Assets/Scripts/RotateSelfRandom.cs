using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelfRandom : MonoBehaviour
{
    
    private float angle;
    
    void Start()
    {
        angle = Random.Range(0.1f, 0.3f);
    
    }

    void Update()
    {
        this.transform.Rotate(0, angle, 0);
    }
}
