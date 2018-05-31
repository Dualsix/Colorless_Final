using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corre_esfera_corre : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3 (transform.forward.x * 0.02f, transform.forward.y * 0.02f, transform.forward.z * 0.02f);
	}
}
