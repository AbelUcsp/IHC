using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    public Camera FPScamera;
    public float HorizontalSpeed;
    public float VerticalSpeed;
    float H;
    float V;
    float xx = 10;
    float Avanzar;

    
    void Start()
    {
        
    }

    void Update()
    {
        H = ( HorizontalSpeed*Input.GetAxis("Mouse X") ); // || Oculus )
        V = ( VerticalSpeed*Input.GetAxis("Mouse Y") ); // || Oculus )
        transform.Rotate(-V/2.1f,H,0);
        FPScamera.transform.Rotate(-V,0,0);
        

        //  ini  avanzar   
        Avanzar = transform.position.x;
        if (KinectManager.instance.IsAvailable)
        {
            
            Avanzar = KinectManager.instance.avanzar;
            transform.Translate(Vector3.forward * Avanzar);
        }
        else
        {
            //Avanzar = transform.position.x + (Input.GetAxis("Vertical") * VerticalSpeed);
            Avanzar =  (Input.GetAxis("Vertical") * VerticalSpeed) /15;
            transform.Translate(Vector3.forward * Avanzar);// * Time.deltaTime);
        }   //  end avanzar   */



    }
}
