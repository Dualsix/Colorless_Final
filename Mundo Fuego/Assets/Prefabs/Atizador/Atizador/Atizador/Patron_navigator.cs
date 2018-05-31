using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron_navigator : MonoBehaviour {

    //public
    public GameObject ia; //el objeto que tiene que llegar al waypoint
    public float beforeTime; //tiempo antes de la accion
    public float afterTime; //tiempo despues de la accion

    //private
    private float empezar; //tiempo para empezar
    private float acabar; //tiempo para acabar
    private bool acabado; //si ha acabado la accion o no
    private Animator anim;

    // Use this for initialization
    void Start () {
        enabled = false; //sera activado por el otro script
        //inicializamos los privates
        empezar = 0;
        acabar = 0;
        acabado = false;
        anim = ia.GetComponent<Animator>();
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
                ////indicamos que puede pasar al siguiente
                //if (ia.GetComponentInParent<Ia_navigator>().Getwaypoint() >= ia.GetComponentInParent<Ia_navigator>().waypoints.Length -1)
                //{
                //    ia.GetComponentInParent<Ia_navigator>().Setwaypoint(0);
                //}
                //else
                //{
                //    ia.GetComponentInParent<Ia_navigator>().Setwaypoint(ia.GetComponentInParent<Ia_navigator>().Getwaypoint() + 1);
                //}
                //se inicializa el script
                Start();
            }
        }
    }
}
