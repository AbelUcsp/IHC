using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 10;
   
   
    void Update()
    {
        //if (Municion.CurrentAmmo >= 1){
        
        
            if (Input.GetButtonDown("Fire1") /* ||  kinect */ ){
                
                Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);
                //instantiatedProjectile.velocity = transform.TransformDirection( new Vector3( 0, 0, speed*2 ) );
                instantiatedProjectile.velocity = transform.TransformDirection( new Vector3( 0, 0, 50) );
                Physics.IgnoreCollision( instantiatedProjectile.GetComponent<Collider>(), transform.root.GetComponent<Collider>() );
         
               //Destroy(projectile, 1.0f);
         
            }
            else if (KinectManager.instance.IsAvailable)
            {
                if(KinectManager.instance.IsFire){ 
                    Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);
                    instantiatedProjectile.velocity = transform.TransformDirection( new Vector3( 0, 0, 50) );
                    Physics.IgnoreCollision( instantiatedProjectile.GetComponent<Collider>(), transform.root.GetComponent<Collider>() );        
                }
            }
    }
    
}
