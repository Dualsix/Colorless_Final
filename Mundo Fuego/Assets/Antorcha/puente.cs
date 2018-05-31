using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puente : MonoBehaviour {

    //Public
    public GameObject[] des;
    public GameObject[] act;
    public GameObject paso;

    //Privates
    private bool apagada;
    private bool encendida;

    // Use this for initialization
    void Start()
    {
        apagada = true;
        encendida = true;
    }

    // Update is called once per frame
    void Update()
    {

        //si alguna de las antorchas que debe estar apagada esta encendida no se abre la puerta
        for (int i = 0; i < des.Length; i++)
        {
            if (des[i].transform.Find("fire").gameObject.activeSelf)
            {
                apagada = false;
            }
        }

        //si alguna de las antorchas que debe estar encendida esta apagada no se abre la puerta
        for (int i = 0; i < act.Length; i++)
        {
            if (!act[i].transform.Find("fire").gameObject.activeSelf)
            {
                encendida = false;
            }
        }
        //solo si estan las antorchas que deben estar se abre la puerta
        if (encendida && apagada)
        {
            paso.SetActive(true);
            gameObject.SetActive(false);
        }
        //llamamos start para volver a inicializar los booleanos a true;
        Start();
    }
}
