using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkAbilitySpawn : MonoBehaviour 
{
	public Animator anim;
	public string animName;
	public string animNameHub;
	public Animator animHub; 

	public float cd; //Tiempo entre abilidades de fuego.
	public float timeLife; //Tiempo que el sprite de la habilidad esta activo.
	public float timeStopDoing; // Tiempo que el personaje esta quieto haciendo la habilidad
	public string button;
	public string ability; 

	public GameObject Sprite; //Prefab/Sprite de la habilidad
	public GameObject Spawner; //GameObject que genera el sprite, dentro del player.

	private float nextAttack, stopPlayer; //Timers auxiliares

	private bool doingAttack; //Realizando la habilidad de fuego 
	public GameObject ink; 

	void FixedUpdate () 
	{	
		if (Input.GetButtonDown (button) && Time.time > nextAttack && !this.GetComponent<InkAbilityController> ().doingAbility) 
		{
			anim.Play(animName);
			animHub.Play(animNameHub);

			if(ability == "Fire"){
				ink.GetComponent<PincelColorController> ().changeColor ("red");
			}
			if(ability == "Barrier"){
				ink.GetComponent<PincelColorController> ().changeColor ("blue");
			}


			//Rotación del personaje hacia el ratón si se esta utilizando el mando y el ratón
			GetComponent<InkMouseRotation> ().RotationMouse();

			//Generación del Gameobject/Sprite de la habilidad de fuego
			Transform rotation = Spawner.transform;
			GameObject clone = Instantiate (Sprite, new Vector3(Spawner.transform.position.x, Spawner.transform.position.y + 0.4f, Spawner.transform.position.z), rotation.rotation);
			clone.GetComponent<DestroyByTime> ().lifetime = timeLife;

			//Inicializamos el timer que controla el tiempo entre habilidades
			nextAttack = Time.time + cd;
			stopPlayer = Time.time + timeStopDoing;

			this.GetComponent<InkAbilityController> ().doingAbility = true;
			this.GetComponent<InkAbilityController> ().movementEnable = false;
			doingAttack = true;
		}

		//Cuando el Sprite se "muere" podemos utilizar otras habilidades
		if (stopPlayer < Time.time && doingAttack) 
		{
			this.GetComponent<InkAbilityController> ().doingAbility = false;
			this.GetComponent<InkAbilityController> ().movementEnable = true;

			doingAttack = false; 
		}
	}

}
