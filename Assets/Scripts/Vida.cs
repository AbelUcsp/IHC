using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    // Start is called before the first frame update
    public float valor = 150;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Recibirdaño(float daño){
        valor -= daño;
        if(valor <0)
        {
            valor = 0;
        }
    }
}
