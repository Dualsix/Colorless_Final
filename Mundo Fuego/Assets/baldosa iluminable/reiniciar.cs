using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reiniciar : MonoBehaviour {
    //apagar baldosas
    //public variables
    public GameObject[] baldosas; //todas las baldosas que deben estar iluminadas para abrir puerta
    public Material no_iluminada; //material de baldosa iluminada
    public Material rojo;
    public GameObject primera;
    //private variables
    private Animator pushButtonDown;
    // Use this for initialization
    void Start () {
        pushButtonDown = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "arma")
        {
            for (int i = 0; i < baldosas.Length; i++)
            {
                pushButtonDown.Play("Palanca_down");
                //cogemos el material y lo cambiamos
                baldosas[i].GetComponent<Renderer>().material = no_iluminada;
                primera.GetComponent<Renderer>().material = rojo;
            }
        }
    }
}
