﻿using UnityEngine;
using UnityEngine.UI;

using Windows.Kinect;

using System.Linq;

using System;
using System.Collections.Generic;



public class KinectManager : MonoBehaviour
{
    private KinectSensor _sensor;

    
    private BodyFrameReader _bodyFrameReader;
    private Body[] _bodies = null;

    public GameObject kinectAvailableText;
    public Text handXText;
    public Text piernas;
    public Text kinect;


    //public Transform padre;
    public float RotationPistola;
    public bool IsAvailable;
    public float Forward;
    public float avanzar = 0f;
    public bool IsFire = false;
    public int FOOTT = 0;

    public static KinectManager instance = null;
    
    //public Windows.Kinect.Joint JointFoot = Windows.Kinect.JointType.JointType_FootRight  ; //JointType_FootRight

    public Body[] GetBodies()
    {
        return _bodies;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {

        //padre = GetComponent<Transform>();


        _sensor = KinectSensor.GetDefault();

        if (_sensor != null)
        {
            IsAvailable = _sensor.IsAvailable;

            kinectAvailableText.SetActive(IsAvailable);
            
            _bodyFrameReader = _sensor.BodyFrameSource.OpenReader();

            if (!_sensor.IsOpen)
            {
                _sensor.Open();
            }

            _bodies = new Body[_sensor.BodyFrameSource.BodyCount];
        }
        
    }

    void Update()
    {
        IsAvailable = _sensor.IsAvailable;

        if (_bodyFrameReader != null)
        {
            var frame = _bodyFrameReader.AcquireLatestFrame();

            if (frame != null)
            {
                frame.GetAndRefreshBodyData(_bodies);

                foreach (var body in _bodies.Where(b => b.IsTracked))
                {

                    Windows.Kinect.Joint pieIzquierdo = body.Joints[JointType.AnkleLeft];
                    Windows.Kinect.Joint pieDerecho = body.Joints[JointType.AnkleRight];
                    Windows.Kinect.Joint cabeza = body.Joints[JointType.WristRight];
                    Windows.Kinect.Joint espina = body.Joints[JointType.SpineBase];
                    
                   // kinect.text  = pieIzquierdo.Position.Z.ToString();
                   // piernas.text   = pieDerecho.Position.Z.ToString();
                   
                    //kinect.text  = espina.Position.Y.ToString();
                    //piernas.text   = cabeza.Position.Y.ToString();

                    
                    float H;
                    float V;

                    //H = ( 2*Input.GetAxis("Mouse X") ); // || Oculus )
                    //V = ( 2*Input.GetAxis("Mouse Y") ); // || Oculus )
                    //padre.Rotate(V,0,0);
                    float distanceSpineWrist=Mathf.Abs(espina.Position.Y - cabeza.Position.Y);
                    kinect.text  = distanceSpineWrist.ToString();
                    if ( distanceSpineWrist > 0.652 ){//(Mathf.Abs(espina.Position.Y) - Mathf.Abs(cabeza.Position.Y)) > 0.18){
                        RotationPistola = 1f;
                    }
                    else if(distanceSpineWrist > 0.17 && distanceSpineWrist < 0.42 ){
                        RotationPistola =  -1f;
                        //handXText.text = "NO caminar"
                    }
                    else{
                        RotationPistola =0;
                    }
                    


                    ///END EDIT
                    // Mover Kinect
                    if ( Mathf.Abs(Mathf.Abs(pieIzquierdo.Position.Z) - Mathf.Abs(pieDerecho.Position.Z)) > 0.12){
                        avanzar = 0.018f;
                        //handXText.text = "caminar";
                    }
                    else{
                        avanzar = 0f;
                        //handXText.text = "NO caminar"
                    }
    
                    //Disparar Kinect
                    //  TrackingConfidence_Low = 0 || TrackingConfidence_High = 1   right = izquierda
                    // HandRightConfidence   HandLeftConfidence                        
                    //if( (body.HandLeftConfidence == TrackingConfidence.High) && (body.HandLeftState == HandState.Lasso))
                    if( (body.HandRightConfidence == TrackingConfidence.High) && (body.HandRightState == HandState.Lasso))
                    {
                        IsFire = true;
                    }
                    else{
                        
                        IsFire = false;
                        /* 
                        Forward = RescalingToRangesB(-1, 1, -8, 8, body.Lean.X);
                        handXText.text = Forward.ToString();
                        */
                    }
                    //END MOVER
                    // SHOOT KINECT

                    /* 
                    if( (body.HandLeftConfidence == TrackingConfidence.High)  && (body.HandLeftState == HandState.Lasso))
                    {
                        IsFire = true;
                    }
                    else{
                        IsFire = false;
                    }

                    */
                    //  END DISPARAR


                    for (Windows.Kinect.JointType jt = Windows.Kinect.JointType.SpineBase; jt <= Windows.Kinect.JointType.ThumbRight; jt++)
                    {
                        Windows.Kinect.Joint sourceJoint = body.Joints[jt];
                        //if(sourceJoint != body.Joints[JointType.SpineBase] ){
                        if(sourceJoint == body.Joints[JointType.ThumbLeft] ){
                            FOOTT = 10;
                            Time.timeScale = 2f;
                        }  
                    }
                }
                
                frame.Dispose();
                frame = null;
            }
        }
    }

    static float RescalingToRangesB(float scaleAStart, float scaleAEnd, float scaleBStart, float scaleBEnd, float valueA)
    {
        return (((valueA - scaleAStart) * (scaleBEnd - scaleBStart)) / (scaleAEnd - scaleAStart)) + scaleBStart;
    }

    void OnApplicationQuit()
    {
        if (_bodyFrameReader != null)
        {
            _bodyFrameReader.IsPaused = true;
            _bodyFrameReader.Dispose();
            _bodyFrameReader = null;
        }

        if (_sensor != null)
        {
            if (_sensor.IsOpen)
            {
                _sensor.Close();
            }

            _sensor = null;
        }
    }
}





