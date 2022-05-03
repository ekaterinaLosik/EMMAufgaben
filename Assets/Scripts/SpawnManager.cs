using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform myPrefab;
    public int count;
    public float range, height;
    
    // Start is called before the first frame update
    void Start()
    {
        while(count != 0){
            var position = new Vector3(Random.Range(-range, range), height, Random.Range(-range, range));
            Instantiate(myPrefab, position, Quaternion.identity);
            count--;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
