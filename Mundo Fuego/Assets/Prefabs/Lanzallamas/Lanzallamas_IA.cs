using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzallamas_IA : MonoBehaviour {
    //public
    public GameObject lanzallamas;
    public float distancePerseguir;

    //private
    private UnityEngine.AI.NavMeshAgent enemy;
    private Transform player;
    private bool random;
    private Vector3 posicion;
    private float tiempoRandom;
    private float distance;
    private bool atack;
    private float timer;
    private Animator anim;

    // Use this for initialization
    void Start () {
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player GameObject").transform;
        random = true;
        atack = true;
        anim = GetComponentInChildren<Animator>();
        tiempoRandom = Random.Range(1f, 3f);
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(player.position, transform.position);
        //si la distancia es inferior a la estipulada perseguimos al personaje
        if (distance <= distancePerseguir)
        {
            if (distance <= 2)
            {
                Ataque_IA();
            }
            else 
            {
                Stop_fire();
                Perseguir_IA();
            }
        }
        else
        {
            Stop_fire();
            distancePerseguir = 4;
            if (random)
            {
                tiempoRandom -= Time.deltaTime;//dejamos tiempo para que se mueva
                //Debug.Log(Vector3.Distance(posicion, transform.position));
                if (Vector3.Distance(posicion, transform.position) == 1)
                {
                    anim.SetBool("walking", false);
                }
                if (tiempoRandom <= 0)
                {
                    Mover_IA();//movemos el slime de manera aleatoria
                    tiempoRandom = Random.Range(5f, 7f);//volvemos a poner un tiempo random
                }
            }
        }
    }

    private void Perseguir_IA()
    {
        anim.SetBool("attack", false);
        anim.SetBool("walking", true);
        posicion = player.position;//cojemos la posicion del player
        distancePerseguir = 6;
        enemy.speed = 1;//ponemos la velocidad a 2
        enemy.SetDestination(new Vector3(posicion.x, posicion.y, posicion.z));//hacemos que vaya a por el player
    }

    private void Mover_IA()
    {
        anim.SetBool("attack", false);
        anim.SetBool("walking", true);
        posicion = transform.position + new Vector3(Random.onUnitSphere.x * 3, 1f, Random.onUnitSphere.z * 3);//le sumamos a la posicion del slime una posicion aleatoria en un radio de 1
        enemy.speed = 0.5f;//ponemos la velocidad a 1
        enemy.SetDestination(new Vector3(posicion.x, posicion.y, posicion.z));//hacemos que se mueva a esa posicion
    }

    private void Ataque_IA()
    {
        anim.SetBool("walking", false);
        anim.SetBool("attack", true);
        lanzallamas.SetActive(true);

    }

    private void Stop_fire()
    {
        lanzallamas.SetActive(false);
    }
}
