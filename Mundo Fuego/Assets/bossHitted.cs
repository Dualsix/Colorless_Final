using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHitted : MonoBehaviour {
	public GameObject boss; 
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "arma" || other.tag == "fire")
		{
			if (!boss.GetComponent<bossAttacks>().inmunidad){
				boss.GetComponent<bossAttacks> ().damaged = true;
				boss.GetComponent<bossAttacks> ().life--;
			}
		}
	}

}
