using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawner_2 : MonoBehaviour {
	private Transform target;
	public GameObject prefab; 

	void Start(){

        GameObject obj_target =  GameObject.FindGameObjectWithTag("Player GameObject");

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
		
	void Update () {
		Vector3 position = target.position;
		position.y = transform.position.y;
		transform.LookAt(position);

		Instantiate(prefab, transform.position, transform.rotation);
		GameObject clone = Instantiate(prefab, transform.position, transform.rotation);
		clone.transform.Rotate (new Vector3 (0, 90, 0));
		clone = Instantiate(prefab, transform.position, transform.rotation);
		clone.transform.Rotate (new Vector3 (0, 180, 0));
		clone = Instantiate(prefab, transform.position, transform.rotation);
		clone.transform.Rotate (new Vector3 (0, 270, 0));

		this.GetComponent<bossSpawner_2> ().enabled = false;  
	}
}
