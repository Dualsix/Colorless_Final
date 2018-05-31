using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class trele2 : MonoBehaviour {
    public int escena;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger Player")
        {
            if (!Globales.fire)
            {
                SceneManager.LoadScene(escena);
                SceneManager.UnloadSceneAsync(4);
            }
        }
    }
}
