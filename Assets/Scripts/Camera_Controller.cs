﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    //public Camera FPScamera;
    public float HorizontalSpeed;
    public float VerticalSpeed;
    float H;
    float V;
    float Avanzar;

    
    void Start()
    {
        
    }

    void Update()
    {
        H = ( HorizontalSpeed*Input.GetAxis("Mouse X") ); // || Oculus )
        V = ( VerticalSpeed*Input.GetAxis("Mouse Y") ); // || Oculus )
        //transform.Rotate(-V/2.1f,H,0);
        transform.Rotate(0,H/2,0);
//        FPScamera.transform.Rotate(-V,0,0);
       

        //  ini_avanzar   Y = 90
        Avanzar = transform.position.x;
        if (KinectManager.instance.IsAvailable)
        {
            
            Avanzar = KinectManager.instance.avanzar;
            //transform.Translate(Vector3.forward * Avanzar); //back    down    forward left    up
            transform.Translate(Vector3.back * Avanzar);
        }
        /*  controller oculus
        else
        {
            Avanzar =  (Input.GetAxis("Vertical") * VerticalSpeed) /100;
            transform.Translate(Vector3.back * Avanzar);// * Time.deltaTime);
            ///Avanzar =  (Input.GetAxis("Horizontal") * VerticalSpeed) /100;
            ///transform.Translate(Vector3.forward * Avanzar);// * Time.deltaTime);
        }   //  end avanzar   */



    }
}
