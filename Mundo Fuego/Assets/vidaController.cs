using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaController : MonoBehaviour {
	public GameObject[] barras; 

	private GameObject global; 

	void Start(){
		global = GameObject.FindGameObjectWithTag ("Global");
	}

	void Update () {
		if (global.GetComponent<Global> ().life < 100) {
			barras [barras.Length - 1].SetActive (false);
			if (global.GetComponent<Global> ().life < 75) {
				barras [barras.Length - 2].SetActive (false);
				if (global.GetComponent<Global> ().life < 50) {
					barras [barras.Length - 3].SetActive (false);
					if (global.GetComponent<Global> ().life < 25) {
						barras [barras.Length - 4].SetActive (false);
					} else {
						barras [barras.Length - 4].SetActive (true);
					}
				} else {
					barras [barras.Length - 3].SetActive (true);
				}
			} else {
				barras [barras.Length - 2].SetActive (true);
			}
		} else {
			barras [barras.Length - 1].SetActive (true);
		}
	}
}
