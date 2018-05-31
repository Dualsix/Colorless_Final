using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonDown: MonoBehaviour { //dont forget to change this to your script name
    //private variables 
    private Animator pushButtonDown;
    //public variables
    public GameObject puerta;
    public GameObject[] traps; //las trampas que desactiva si es que las tiene

    void Start()
    {
        pushButtonDown = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player Collider")
        {
            pushButtonDown.SetBool("baja", true);//here you place animation name :D
            puerta.SetActive(false);
            for(int i = 0; i < traps.Length; i++)
            {
                traps[i].SetActive(false);
            }
        }
    }
}