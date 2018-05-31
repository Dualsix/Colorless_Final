using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDashEnabled : MonoBehaviour {
	public GameObject player; 

	void OnTriggerEnter(Collider other)
	{
		if (LayerMask.LayerToName (other.gameObject.layer) == "Colision Player") 
		{
			player.GetComponent<InkDash>().stopDash = true; 
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (LayerMask.LayerToName (other.gameObject.layer) == "Colision Player") 
		{
			player.GetComponent<InkDash>().stopDash = false; 
		}
	}
}
