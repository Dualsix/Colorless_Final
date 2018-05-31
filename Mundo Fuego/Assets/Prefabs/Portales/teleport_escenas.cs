using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class teleport_escenas : MonoBehaviour {
    //public variables
    public GameObject[] des;
    public GameObject[] act;
    //private variables
    //Privates
    private bool apagada;
    private bool encendida;

    // Use this for initialization
    void Start () {
        apagada = true;
        encendida = true;
    }
	
	// Update is called once per frame
	void Update () {
        apagada = true;
        encendida = true;
        //si alguna de las antorchas que debe estar apagada esta encendida no va el portal
        for (int i = 0; i < des.Length; i++)
        {
            if (des[i].transform.Find("fire").gameObject.activeSelf)
            {
                apagada = false;
            }
        }

        //si alguna de las antorchas que debe estar encendida esta apagada no va el portal
        for (int i = 0; i < act.Length; i++)
        {
            if (!act[i].transform.Find("fire").gameObject.activeSelf)
            {
                encendida = false;
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger Player")
        {
            if (encendida && apagada)
            {
                Globales.fire = true;
                SceneManager.LoadScene(4);
                SceneManager.UnloadSceneAsync(1);
            }
        }
    }
}
