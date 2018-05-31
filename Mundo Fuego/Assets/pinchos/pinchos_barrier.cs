using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinchos_barrier : MonoBehaviour {
    //public variables
    public GameObject[] pinchos;//pinchos que se activaran cuando pases
    public GameObject[] enemies;//enemigos que debes vencer para pasar
    //private variables
    private bool defeat;//sirve para controlar que solo se active una vez

	// Use this for initialization
	void Start () {
        defeat = false;
	}
	
	// Update is called once per frame
	void Update () {
        defeat = true;
        //miramos si hay bichos por derrotar
        for(int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].activeSelf)
            {
                defeat = false;
                break;
            }
        }
        //si no hay mas bichos por derrotar desactivamos los pinchos
        if (defeat)
        {
            for(int i = 0; i < pinchos.Length; i++)
            {
                pinchos[i].SetActive(false);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        //si el jugador entra en la sala se activa
        if(other.tag == "Trigger Player")
        {
            //en caso de que ya haya derrotado a todos no se activa
            if(!defeat)
            {
                //activamos la barrera solo si aun hay bichos en la sala
                for(int i = 0; i < pinchos.Length; i++)
                {
                    pinchos[i].SetActive(true);
                }
            }
        }
    }
}
