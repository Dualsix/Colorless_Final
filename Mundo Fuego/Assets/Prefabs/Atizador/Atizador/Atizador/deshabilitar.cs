using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deshabilitar : MonoBehaviour {
    public GameObject parent;

    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "fire" || other.tag == "arma")
        {
            parent.SetActive(false);
        }
    }
}
