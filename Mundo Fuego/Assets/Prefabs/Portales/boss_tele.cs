using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class boss_tele : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger Player")
        {
            if (Globales.gato && Globales.fire) {
                SceneManager.LoadScene(3);
                SceneManager.UnloadSceneAsync(4);
            }
        }
    }
}
