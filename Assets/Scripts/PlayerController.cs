using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlayerController : MonoBehaviour
{
    public VirtualButtonBehaviour button_left;
    public VirtualButtonBehaviour button_right;
    public VirtualButtonBehaviour button_forward;
    public VirtualButtonBehaviour button_back;

    public float rotationSpeed = 2f;
    public float movementSpeed = 0.01f;
    private float angle;
    private GameObject child;
    private int itemsCount;
    private int horizontal;
    private int vertical;

    void Start(){
        child = this.transform.GetChild(0).gameObject;
        RegisterButtons();
    }

    void Update()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = horizontal;
        float moveVertical = vertical;

        angle += moveHorizontal * rotationSpeed * Time.deltaTime;        
        Vector3 targetDirection = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        Quaternion rotation = Quaternion.LookRotation(targetDirection);
        transform.localPosition += targetDirection * moveVertical * movementSpeed;
        transform.localRotation = rotation;
        child.transform.Rotate(moveVertical, 0, 0, Space.Self);

    }

     void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Item")) {
            Destroy(other.gameObject);
            itemsCount++;
            Debug.Log("Items collected: " + itemsCount);
        }
    }

    void RegisterButtons(){
        button_left.RegisterOnButtonPressed(OnButtonPressed);
        button_left.RegisterOnButtonReleased(OnButtonReleased);
        button_right.RegisterOnButtonPressed(OnButtonPressed);
        button_right.RegisterOnButtonReleased(OnButtonReleased);
        button_forward.RegisterOnButtonPressed(OnButtonPressed);
        button_forward.RegisterOnButtonReleased(OnButtonReleased);
        button_back.RegisterOnButtonPressed(OnButtonPressed);
        button_back.RegisterOnButtonReleased(OnButtonReleased);
    }

     public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "back":
                Debug.Log("Pressed forward");
                vertical = -1;
                break;
            case "forward":
                Debug.Log("Pressed back");
                vertical = 1;
                break;
            case "left":
                Debug.Log("Pressed Left");
               horizontal = -1;
                break;
            case "right":
                Debug.Log("Pressed Right");
               horizontal = 1;
                break;
        }
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "back":
                vertical = 0;
                break;
            case "forward":
                vertical = 0;
                break;
            case "left":
                horizontal = 0;
                break;
            case "right":
                horizontal = 0;
                break;
        }
    }
   
}
