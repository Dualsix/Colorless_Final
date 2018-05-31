using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawner_1 : MonoBehaviour {
	private Transform target;
	public float newtAttack; 
	public GameObject prefab; 

	private float timer;
	private float count = 0;

	void Start(){
		timer = Time.time + newtAttack;

        GameObject obj_target = GameObject.FindGameObjectWithTag("Player GameObject");

        if (obj_target == null)
        {
            Debug.Log("No se ha encontrado al jugador");
            this.gameObject.SetActive(false);
        }
        else
        {
            target = obj_target.transform;
        }
    }

	// Update is called once per frame
	void Update () {
		Vector3 position = target.position;
		position.y = transform.position.y;
		transform.LookAt(position);

		if (Time.time > timer ){
			Instantiate(prefab, transform.position, transform.rotation);
			timer = Time.time + newtAttack; 
			count++;
		}

		if (count == 3) {
			count = 0;
			this.GetComponent<bossSpawner_1> ().enabled = false;  
		}
	}
}
