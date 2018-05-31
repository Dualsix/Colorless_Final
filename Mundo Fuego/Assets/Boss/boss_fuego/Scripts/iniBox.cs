using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iniBox : MonoBehaviour {
	public float time; 
	private float timer;
	public Transform target;

	void Start(){
		timer = Time.time + time;
	}

	void Update(){
		Vector3 position = target.position;
		position.y = transform.position.y;
		transform.LookAt(position);

		if (Time.time > timer){
			GetComponent<bossAttacks> ().enabled = true; 
			this.enabled = false; 
		}
	}

}
