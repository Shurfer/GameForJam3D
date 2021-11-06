using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed;
    public float backSpeed;

    public Transform[] railsTr;
    
    void LeftMove()
    {
        
        if( transform.position.x>-0.9f)
        transform.position -= new Vector3( 1, 0, 0);
        Debug.Log("Left");
    }
    
    void RightMove()
    {
        if( transform.position.x<0.9f)
        transform.position += new Vector3( 1, 0, 0);
        Debug.Log("Right");
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("KeyCode.A");
            LeftMove();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("KeyCode.D");
            RightMove();
        }
        // transform.position += new Vector3( Input.GetAxis("Horizontal")*Time.fixedDeltaTime*backSpeed, 0, Input.GetAxis("Vertical")*Time.fixedDeltaTime*forwardSpeed);
    }
    
    private void FixedUpdate()
    {
        transform.position += new Vector3( 0, 0, Time.fixedDeltaTime*forwardSpeed);

        // transform.position += new Vector3( Input.GetAxis("Horizontal")*Time.fixedDeltaTime*backSpeed, 0, Input.GetAxis("Vertical")*Time.fixedDeltaTime*forwardSpeed);
    }
}
