using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daño : MonoBehaviour
{
    float bulletDamage = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision info)

    {
        info.transform.SendMessage("ApplyDamage", bulletDamage, SendMessageOptions.DontRequireReceiver);
    }
}
