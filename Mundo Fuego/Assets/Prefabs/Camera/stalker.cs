using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stalker : MonoBehaviour {
	public Transform target; 
    private Vector3 position; //posicion del stalker
	private float distance_y;

    // Use this for initialization
    void Start () {
		distance_y = transform.position.y - target.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		position = target.position;  //cogemos la posicion del personaje

		transform.position = new Vector3(position.x, position.y + distance_y, position.z);  //movemos el stalker
        
    }
}
