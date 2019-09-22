using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{
    public Transform padre;
    public float HorizontalSpeed = 2;
    public float VerticalSpeed = 2;

    float H;
    float V;
    void Start()
    {
        padre = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        H = ( HorizontalSpeed*Input.GetAxis("Mouse X") ); // || Oculus )
        V = ( VerticalSpeed*Input.GetAxis("Mouse Y") ); // || Oculus )
        padre.Rotate(V,0,0);
    }
}
