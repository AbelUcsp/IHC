using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorRaycast : MonoBehaviour
{
    public double theDamage = 100;

    void Update()
    {

        
        RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f, Screen.height*0.5f, 0f));


        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(new Vector3(Screen.width*0.5f, 0f, Screen.height*0.5f) , new Vector3(0f,0f,0f), 100))
            {
                //hit.transform.SendMessage("ApplyDamage", theDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    
}
