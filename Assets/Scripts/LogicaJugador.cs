using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaJugador : MonoBehaviour
{
    public Vida vida;
    public bool death = false;

    void Start()
    {
        vida = GetComponent<Vida>();    
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
    }

    void RevisarVida()
    {
        if(death){return;}
        if(vida.valor <= 0){    
            death = true;
        }
    }
    void ReiniciarJuego(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
