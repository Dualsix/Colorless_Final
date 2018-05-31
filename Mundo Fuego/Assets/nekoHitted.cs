using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class nekoHitted : MonoBehaviour {
    public float life;
    public GameObject slider_obj;
    public GameObject slider;

    private void Start()
    {
        slider_obj.SetActive(true);
    }

    private void Update()
    {
        if (life > 0)
        {
            slider.GetComponent<Slider>().value = life;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "arma" || other.tag == "fire")
        {
            life-= 10;
            if (life <= 0)
            {
                Globales.gato = true;
                SceneManager.LoadScene(4);
            }
        }
    }

}
