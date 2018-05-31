using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronAtaqueNav : MonoBehaviour {
    //public
    public GameObject ia; //el objeto que tiene que llegar al waypoint
    public float beforeTime; //tiempo antes de la accion
    public float afterTime; //tiempo despues de la accion

    //private
    private float empezar; //tiempo para empezar
    private float acabar; //tiempo para acabar
    private bool acabado; //si ha acabado la accion o no

    // Use this for initialization
    void Start () {
        enabled = false; //sera activado por el otro script
        //inicializamos los privates
        empezar = 0;
        acabar = 0;
        acabado = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!ia.activeSelf)
        {
            enabled = false;
        }
        if (!acabado)
        {
            empezar += Time.deltaTime;

            //no realizamos la accion hasta que pase el tiempo 
            if (empezar >= beforeTime)
            {
                //ponemos la animacion de ataque

                acabado = true;
            }
        }
        else
        {
            acabar += Time.deltaTime;

            //no seguimos hasta que pase el tiempo de espera
            if (acabar >= afterTime)
            {
                //se inicializa el script
                Start();
            }
        }
    }
}
