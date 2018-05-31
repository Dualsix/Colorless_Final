using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Slime : MonoBehaviour {
    //publics
    public float distancePerseguir;

    //privates
    private UnityEngine.AI.NavMeshAgent slime;
    private Transform player;
    private float distance;
    private bool random;
    private Vector3 posicion;
    private float tiempoRandom;

    // Use this for initialization
    void Start () {
        slime = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player GameObject").transform;
        random = true;
        tiempoRandom = Random.Range(1f, 3f);
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(player.position, transform.position);
        //si la distancia es inferior a la estipulada perseguimos al personaje
        if(distance <= distancePerseguir)
        {
            Perseguir_IA();
        }
        else
        {
            if (random)
            {
                tiempoRandom -= Time.deltaTime;//dejamos tiempo para que se mueva
                if (tiempoRandom <= 0)
                {
                    Mover_IA();//movemos el slime de manera aleatoria
                    tiempoRandom = Random.Range(5f, 7f);//volvemos a poner un tiempo random
                }
            }
        }
	}

    private void Mover_IA()
    {
        posicion = transform.position + new Vector3(Random.onUnitSphere.x*3, 1f, Random.onUnitSphere.z*3);//le sumamos a la posicion del slime una posicion aleatoria en un radio de 1
        slime.speed = 0.5f;//ponemos la velocidad a 1
        slime.SetDestination(new Vector3 (posicion.x, posicion.y, posicion.z));//hacemos que se mueva a esa posicion
    }

    private void Perseguir_IA()
    {
        posicion = player.position;//cojemos la posicion del player
        slime.speed = 1;//ponemos la velocidad a 2
        slime.SetDestination(new Vector3(posicion.x, posicion.y, posicion.z));//hacemos que vaya a por el player
    }
}
