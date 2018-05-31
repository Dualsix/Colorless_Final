using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerBox : MonoBehaviour {
	public GameObject boss;
	public GameObject wall; 

	private void OnTriggerExit(Collider other)
	{
		//si el jugador entra en la sala se activa
		if(other.tag == "Trigger Player")
		{
			boss.SetActive (true);
			wall.SetActive (true);
			Destroy (this);
		}
	}
}
