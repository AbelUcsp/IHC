using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{
    public Transform padre;
    public float HorizontalSpeed = 2;
    public float VerticalSpeed = 2;
    private float RotadorPistola;

    float H;
    float V;
    void Start()
    {
        padre = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       // H = ( HorizontalSpeed*Input.GetAxis("Mouse X") ); // || Oculus )
        //V = ( VerticalSpeed*Input.GetAxis("Mouse Y") ); // || Oculus )
     //   V = ( VerticalSpeed*Mathf.Clamp(float value, float min, float max) ); // || Oculus )
        if (KinectManager.instance.IsAvailable)
        {    
            RotadorPistola = KinectManager.instance.RotationPistola;
            //padre.Rotate( Mathf.Clamp( RotadorPistola , -0.5f, 0.1f) ,0 ,0 );
            padre.Rotate( Mathf.Clamp( RotadorPistola , -0.2f,  0.2f)   ,0 ,0 );
        }
        else
        {
            H = ( HorizontalSpeed*Input.GetAxis("Mouse X") ); 
            V = ( VerticalSpeed*Input.GetAxis("Mouse Y") ); 
            //V = ( VerticalSpeed*Mathf.Clamp(float value, float min, float max) );
           // padre.Rotate(V,0,0);
            
        }


    }
}
