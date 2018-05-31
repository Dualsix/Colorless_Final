using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicion : MonoBehaviour {
    //public
    public GameObject player;

    //private

	// Use this for initialization
	void Start () {
		if((Globales.gato == true) || (Globales.fire == true))
        {
            player.transform.position = transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
