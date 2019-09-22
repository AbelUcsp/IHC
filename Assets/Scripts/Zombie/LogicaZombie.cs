using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;




public class LogicaZombie : MonoBehaviour
{

    /* 
    private GameObject target;
     private NavMeshAgent Agente;
     private Vida vidaZombie;
     private Animator animator;
     private Collider collider;
     private Vida vidaPlayer;
     private LogicaJugador logicaJugador;
     public bool death = false;     
     public bool estaAtacando = false;
     public float speed = 1.0f;
     public float angularspeed = 120;
     public float daño = 20;
     public bool EstaMirando = false;
     public Transform other;
    void Start()
    {
        target = GameObject.Find("Player");
        vidaPlayer = target.GetComponent<Vida>();
        if(vidaPlayer == null){
            throw new System.Exception("Error Jugador no tiene Comp Vida");
        }
        logicaJugador = target.GetComponent<LogicaJugador>();

        Agente = GetComponent<NavMeshAgent>();
        vida = GetComponent<Vida>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }


    void Update()
    {
        Atacar();
        RevisaVida();
        Perseguir();
        RevisarAttack();
        EstadeFrenteDelPlayer();
    }

    void EstadeFrenteDelPlayer(){
        Vector3 adelante = transform.forward;
        Vector3 targetJugador = (GameObject.Find("Jugador").transform.position - transform.position).normalized;

        if(Vector3.Dot(adelante,targetJugador)< 0.6f)
        {
            EstaMirando = false;
        }
        else
        {
            EstaMirando = true;
        }
    }

    void RevisaVida()
    {
        if (death) return;
        if(vida.valor <= 0)
        {
            death = true;
            Agente.isStopped = true;
            collider.enabled = false;
            animator.CrossFadeInFixedTime("death", 0.1f);
            Destroy(gameObject, 3f);
        }

    }    
    void Perseguir()
    {
        if (death) return;
        if (logicaJugador.death) return;
        Agente.destination = target.transform.position;
    }

    void RevisarAtaque()
    {
        if (death) return;
        if (estaAtacando) return;
        if (logicaJugador.death) return;
        float distanciaDelBlanco = Vector3.Distance(target.transform.position, transform.position);

        if(distanciaDelBlanco <= 2.0 && EstaMirando)
        {
            Atacar();
        }
    }

    void Atacar()
    {
        vidaJugador.RecibirDaño(daño);
        Agente.speed = 0;
        Agente.angularSpeed = 0;
        estaAtacando = true;
        animator.SetTrigger("DebeAtacar");
        Invoke("ReiniciarAtaque", 1.5f);
    }

    void ReiniciarAtaque()
    {
        estaAtacando = false;
        Agente.speed = speed;
        Agente.angularSpeed = angularSpeed;
    }


*/
}



