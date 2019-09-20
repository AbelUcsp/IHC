using UnityEngine;
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

    public bool IsAvailable;
    public float Forward;
    public float avanzar = 0f;
    public bool IsFire;
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

    // Use this for initialization
    void Start()
    {
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
        
       //_sensor.SkeletonStream.Enable();//HABILITAR STREAM SKELETON
    }

    // Update is called once per frame
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

                    IsAvailable = true;
                    //MOVER CON MANO IZQUIERDA
                    //  TrackingConfidence_Low = 0 || TrackingConfidence_High = 1   right = izquierda
                           // HandRightConfidence   HandLeftConfidence                        
                    if (body.HandRightConfidence == TrackingConfidence.High )//|| body.HandRightState == HandState.Lasso)
                    {
                        IsFire = true;
                        avanzar = 0.02f;
                    }
                    else{
                        avanzar = 0f;
                        Forward = RescalingToRangesB(-1, 1, -8, 8, body.Lean.X);
                        handXText.text = Forward.ToString();
                    }
                    //END MOVER


                    //DISPARAR
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
                
                
                //if(_bodies[0].IsTracked()){
                   // IReadOnlyDictionary<JointType, Joint>  joints = body.joints;
                  //  Windows.Kinect.Body body = this.BodySourceManager.GetClosestBody();
           
             //  }

                frame.Dispose();
                frame = null;

                ///iNI SKELETON
                

            }
            
        }



        //Skeleton[] skeletons = new Skeleton[0];
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





