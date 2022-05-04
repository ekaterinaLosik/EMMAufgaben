using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float rotationSpeed = 2f;
    public float movementSpeed = 0.01f;
    private float angle;
    private GameObject child;
    private int itemsCount;

    void Start(){
        child = this.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        angle += moveHorizontal * rotationSpeed * Time.deltaTime;        
        Vector3 targetDirection = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        Quaternion rotation = Quaternion.LookRotation(targetDirection);
        transform.position += targetDirection * moveVertical * movementSpeed;
        transform.localRotation = rotation;
        child.transform.Rotate(moveVertical, 0, 0, Space.Self);
      //  GetComponent<Rigidbody>().velocity = Vector3.zero;

    }

     void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Item")) {
            Destroy(other.gameObject);
            itemsCount++;
            Debug.Log("Items collected: " + itemsCount);
        }
    }
   
}
