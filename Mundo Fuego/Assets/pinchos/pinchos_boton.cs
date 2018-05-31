using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinchos_boton : MonoBehaviour {
    //Public variables
    public GameObject[] enemies;
    //Private variables
    private bool defeted;

	// Use this for initialization
	void Start () {
        defeted = false;
	}
	
	// Update is called once per frame
	void Update () {
        //ponemos el defeted a true
        defeted = true;
        //si algun enemigo sigue vivo volvemos a poner el defeted a false
        for (int i = 0; i < enemies.Length; i++) {
            if(enemies[i].activeSelf == true)
            {
                defeted = false;
            }
        }
        //si se han derrotado a todos los enemigos asignados desactivamos los pinchos
        if (defeted)
        {
            gameObject.SetActive(false);
        }
	}
}
