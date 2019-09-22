using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoBala : MonoBehaviour
{
    public AudioClip GunSound;
    AudioSource fuente;
    void Start()
    {
        fuente =  GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            fuente.clip = GunSound;
            fuente.Play();
        }
    }
}
