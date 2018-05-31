using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkDash : MonoBehaviour 
{
	public bool stopDash;

	public float cd_Dash; //Tiempo entre "dashes".
	public float timeDoingDash;  //Tiempo haciendo el dash

	public float velocity; //Velocidad del dash 

	public bool doRotationMouse; //Variable que controla la rotación si se esta utilizando el teclado y ratón (no el mando).

	private GameObject rotationPlayer; //Controlador de la rotación del personaje, se utilizará para saber la dirección en la que avanzar haciendo el dash

	private float nextDash, timer; //Timer auxiliares

	public bool doingDash; //Realizando el dash


	void Start()
	{
		doingDash = false; 
		rotationPlayer = GameObject.FindGameObjectWithTag ("Rotation Player");
		stopDash = false; 
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Jump") && Time.time > nextDash && !doingDash && !stopDash && !this.GetComponent<InkAbilityController> ().doingAbility)
		{
			//Rotación del personaje hacia el ratón si se esta utilizando el mando y el ratón
			GetComponent<InkMouseRotation> ().RotationMouse();

			//Inicializamos el timer que controla el tiempo entre "dashes"
			nextDash = Time.time + cd_Dash; 

			this.GetComponent<InkAbilityController> ().doingAbility = true; 
			this.GetComponent<InkAbilityController> ().movementEnable = false;

			doingDash = true;
			doRotationMouse = true; 
			stopDash = false; 
		}

		//Movimento de dash
		if (doingDash) 
		{
			transform.localPosition += rotationPlayer.transform.forward * velocity * Time.fixedDeltaTime;
			timer += Time.fixedDeltaTime; 
		}

		//Stop del dash
		if ((doingDash && timer > timeDoingDash) || stopDash) 
		{
			timer = 0;
			doingDash = false; 
			this.GetComponent<InkAbilityController> ().doingAbility = false; 
			this.GetComponent<InkAbilityController> ().movementEnable = true;
		}
			
	}
}
