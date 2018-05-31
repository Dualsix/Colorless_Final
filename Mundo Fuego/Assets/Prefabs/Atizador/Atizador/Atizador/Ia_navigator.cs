using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ia_navigator : MonoBehaviour {

    //publics
    public float distancePerseguir;
    public GameObject[] waypoints;
    public float beforeTime; //tiempo de la accion
    public float afterTime; //tiempo despues de la accion
    public float wait_atack; //tiempo


    //private
    private Transform player;
    private UnityEngine.AI.NavMeshAgent atiza;
    private int waypoint;
    private Animator anim;
    private bool first;
    private float time;
    private float empezar; //tiempo para empezar
    private float acabar; //tiempo para acabar
    private bool acabado; //si ha acabado la accion o no
    private float waiter; //tiempo para esperar
    private bool atacar;

    // Use this for initialization
    void Start () {
        atiza = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player GameObject").transform;
        waypoint = 0;
        anim = GetComponentInChildren<Animator>();
        first = true;
        empezar = 0;
        acabar = 0;
        acabado = false;
        waiter = 0;
        atacar = false;
    }
	
	// Update is called once per frame
	void Update () {
        //calculamos la distancia con el personaje
		float distance = Vector3.Distance(player.position, transform.position);
        //si la distancia es inferior a un numero perseguimos al personaje
        if (distance <= distancePerseguir)
        {
            distancePerseguir = 4;
            if (first)
            {
                anim.SetBool("walk", false);
                transform.LookAt(player.transform.position);
                atiza.isStopped = true;
                anim.SetBool("pre", true);
                time = Time.time;
                first = false;
            }
            else
            {
                if ((Time.time - time) >= 0.7)
                {
                    atiza.isStopped = false;
                    Perseguir_IA();
                }
            }
            
            //calculamos la distancia con el personaje
            float distFight = Vector3.Distance(player.position, transform.position);
            if (distFight <= 1)
            {
                Do_atack();
                if (atacar)
                {
                    anim.SetBool("atack", true);
                    anim.SetBool("walk", false);
                }
            }
            else
            {
                atacar = false;
                anim.SetBool("atack", false);
            }
        }
        else
        {
            distancePerseguir = 2;
            first = true;
            //calculamos la distancia con el waypoint
            float dist_waypoint = Vector3.Distance(transform.position, waypoints[waypoint].transform.position);
            if (dist_waypoint <= 1)
            {
                Do_waypoint();
            }
            else
            {
                Mover_IA();
            }
        }

    }
    private void Mover_IA()
    {
        Vector3 posicion = waypoints[waypoint].transform.position;//le sumamos a la posicion del slime una posicion aleatoria en un radio de 1
        atiza.speed = 0.5f;//ponemos la velocidad a 1
        atiza.SetDestination(new Vector3(posicion.x, posicion.y, posicion.z));//hacemos que se mueva a esa posicion
        anim.SetBool("walk", true);
        anim.SetBool("Idle", false);
        anim.speed = 1;
    }
    //esta funcion persigue al jugador
    private void Perseguir_IA()
    {
        Vector3 posicion = player.position;//cojemos la posicion del player
        atiza.speed = 1;//ponemos la velocidad a 2
        atiza.SetDestination(new Vector3(posicion.x, posicion.y, posicion.z));//hacemos que vaya a por el player
        anim.SetBool("Idle", false);
        anim.SetBool("walk", true);
        anim.SetBool("pre", false);
        anim.speed = 1.5f;
    }
   
    private void Do_waypoint()
    {
        if (!acabado)
        {
            empezar += Time.deltaTime;

            //no realizamos la accion hasta que pase el tiempo 
            anim.SetBool("walk", false);
            anim.SetBool("pre", false);
            //anim.SetBool("dead", false);
            anim.SetBool("atack", false);
            anim.SetBool("Idle", true);

            if (empezar >= beforeTime)
            {
                //ponemos la animacion

                acabado = true;
            }
        }
        else
        {
            acabar += Time.deltaTime;

            //no seguimos hasta que pase el tiempo de espera
            if (acabar >= afterTime)
            {
                //indicamos que puede pasar al siguiente
                if (waypoint >= waypoints.Length - 1)
                {
                    waypoint = 0; 
                }
                else
                {
                    waypoint++;
                }
                //se inicializa el script
                empezar = 0;
                acabar = 0;
                acabado = false;
            }
        }
    }

    private void Do_atack()
    {
        if (!atacar)
        {
            waiter += Time.deltaTime;
            if(waiter >= wait_atack)
            {
                waiter = 0;
                atacar = true;
            }
        }
    }
}

