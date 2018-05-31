using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encender : MonoBehaviour {

    //Public
    public GameObject[] torches;
    public GameObject encendido;

    //Privates
    private bool first;
    private float time;
    private bool on;

	// Use this for initialization
	void Start () {
        first = true;
        time = 0;
        on = false;
    }
	
	// Update is called once per frame
	void Update () {

        //esto lo hacemos para dejar un margen entre encendido y apagado
        if (!first)
        {
            time += Time.deltaTime;
            if(time > 0.5)
            {
                first = true;
                time = 0;
            }
        }
		
	}

    //cuando la liana golpea la palanca se encienden las antorchas vinculadas a ella
    void OnTriggerEnter(Collider other)
    {
        //encendemos los sprites de todas als antorchas
        if ((other.tag == "arma")  && first)
        {
            if (!on) {
                encendido.GetComponent<MeshRenderer>().enabled = true;
                GetComponent<MeshRenderer>().enabled = false;
                on = true;
            }
            else
            {
                encendido.GetComponent<MeshRenderer>().enabled = false;
                GetComponent<MeshRenderer>().enabled = true;
                on = false;
            }
            for (int i = 0; i < torches.Length; i++)
            {
                if (!torches[i].transform.Find("fire").gameObject.activeSelf)
                {
                    torches[i].transform.Find("fire").gameObject.SetActive(true);
                }
                else
                {
                    torches[i].transform.Find("fire").gameObject.SetActive(false);
                }
                if(i == torches.Length - 1)
                {
                    first = false;
                    time = 0;
                }
            }
        }
    }
}
