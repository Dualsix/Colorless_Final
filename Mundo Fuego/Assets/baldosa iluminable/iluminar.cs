using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iluminar : MonoBehaviour {
    //Public variables
    public GameObject[] baldosas; //las baldosas que le rodean 
    public Material iluminada; //material de baldosa iluminada
    public Material active; //material de la baldosa en la que estas
    //Private Variables
    private string name_material;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //limpiamos el (Instantiate) del nombre
        name_material = GetComponent<Renderer>().material.name.Substring(0, GetComponent<Renderer>().material.name.Length - 11);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //miramos si lo que choca es el protagonista
		if (collision.gameObject.tag== "Player GameObject")
        {
            //si ya esta ilumianda o asignada no hacemos nada
            if (name_material != iluminada.name && name_material != active.name)
            {
                //miramos todas las baldosas de alrededor
                for (int i = 0; i < baldosas.Length; i++)
                {
                    //limpiamos el (Instantiate) del nombre
                    Material aux = baldosas[i].GetComponent<Renderer>().material;
                    string name = aux.name.Substring(0, aux.name.Length - 11);
                    //mriamos si el material de alguna es la de activación
                    if (name == active.name)
                    {
                        //en caso afirmativo ponemos la activada como iluminada y la que estas en activa
                        baldosas[i].GetComponent<Renderer>().material = iluminada;
                        GetComponent<Renderer>().material = active;
                    }
                }
            }
        }
    }
}
