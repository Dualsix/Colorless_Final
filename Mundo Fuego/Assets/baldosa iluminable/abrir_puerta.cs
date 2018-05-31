using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrir_puerta : MonoBehaviour {
    //se pone en la puerta que quieres que se abra
    //public variables
    public GameObject[] baldosas; //todas las baldosas que deben estar iluminadas para abrir puerta
    public Material no_iluminada; //material de baldosa iluminada
    public Material iluminada; //material de baldosa iluminada
    public Material active; //material de la baldosa en la que estas
    //private variables
    private int roja;
    private bool cerrada;

    // Use this for initialization
    void Start () {
        cerrada = true;
	}
	
	// Update is called once per frame
	void Update () {
        cerrada = false;
		for(int i = 0; i < baldosas.Length; i++)
        {
            //cogemos el material
            Material aux = baldosas[i].GetComponent<Renderer>().material;
            //quitamos el (Instantiate)
            string name = aux.name.Substring(0, aux.name.Length - 11);
            //si hay alguna no iluminada ponemos el cerrada a true
            if (name == no_iluminada.name)
            {
                cerrada = true;
                break;
            }
            //cogemos la posicion de la roja
            if(name == active.name)
            {
                roja = i;
            }
        }

        if (!cerrada)
        {
            baldosas[roja].GetComponent<Renderer>().material = iluminada;
            gameObject.SetActive(false);
        }
	}
}
