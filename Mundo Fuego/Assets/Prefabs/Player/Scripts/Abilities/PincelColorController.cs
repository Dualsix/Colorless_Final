using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PincelColorController : MonoBehaviour {
	public GameObject red;
	public GameObject green;
	public GameObject blue;

	public void changeColor(string color){
		switch (color){
			case "red":
				red.SetActive (true);
				blue.SetActive (false);
				green.SetActive (false);
				break;
			case "blue":
				red.SetActive (false);
				blue.SetActive (true);
				green.SetActive (false);
				break;
			case "green":
				red.SetActive (false);
				blue.SetActive (false);
				green.SetActive (true);
				break;
		}
	}
}
