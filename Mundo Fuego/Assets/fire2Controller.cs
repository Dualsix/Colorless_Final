using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class fire2Controller : MonoBehaviour {

	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene(0);
			SceneManager.UnloadSceneAsync(2);
		}	
		if (Input.GetKey (KeyCode.Keypad0)) {
			SceneManager.LoadScene(1);
			SceneManager.UnloadSceneAsync(2);
		}	
	}
}
