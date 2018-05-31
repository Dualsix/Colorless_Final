using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player interactions.
///	Objetivos: Controlar las interaciones al chocar con objetos. 
/// 	-> Cambio de color y invulneravilidad al recibir daño
/// 	->
/// </summary>
public class playerInteractions : MonoBehaviour {
	//PUBLIC
	public GameObject player; 
	public bool invulnerable;
	public Material material;

	//PRIVATE
	private float inv_timer;
	private float inv_colorTimer;
	private bool inv_color; 

    void Start () {
		inv_timer = 1.5f;
		inv_colorTimer = 0.0f;
		inv_color = false; 
	}
	
	// Update is called once per frame
	void Update () {
		//Controlamos el cambio de color y la invulneravilidad
		if (invulnerable) {
			inv_timer -= Time.deltaTime; 
			inv_colorTimer += Time.deltaTime; 
			if (inv_colorTimer >= 0.2f) {
				inv_colorTimer = 0.0f;
				if (inv_color) {
					player.GetComponent<Renderer> ().material.color = Color.red;

					inv_color = false;
				} else {
					player.GetComponent<Renderer> ().material = material;
					inv_color = true;
				}
			}
		}

		if (inv_timer <= 0.0f) {
			inv_timer = 1.5f;
			invulnerable = false; 
			player.GetComponent<Renderer> ().material = material;
		}
    }

    //COLISIONS 
    void OnTriggerEnter(Collider col)
    {
		if (((col.gameObject.tag == "pinchos") || (col.gameObject.tag == "shoot") || (col.gameObject.tag == "Enemy")) && !invulnerable)
        {
			invulnerable = true;
			inv_color = true;

			player.GetComponent<Renderer> ().material.color = Color.magenta;
			Global.Instance.life -= 20;
        }
    }
}
