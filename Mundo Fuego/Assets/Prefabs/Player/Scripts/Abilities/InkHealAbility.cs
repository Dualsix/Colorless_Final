using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkHealAbility : MonoBehaviour {
	public float cd; //Tiempo entre abilidades de fuego.
	public float timeLife; //Tiempo que el sprite de la habilidad esta activo.
	public string button;

	public Animator anim;
	public string animName;
	public string animNameHub;
	public Animator animHub; 

	public GameObject Sprite; //Prefab/Sprite de la habilidad
	public GameObject Spawner; //GameObject que genera el sprite, dentro del player.

	private float nextHeal, timeHealing; //Timers auxiliares
	public GameObject ink; 

	public GameObject icon;
	public GameObject iconSpawner;

	void FixedUpdate () 
	{	
		if (Input.GetButtonDown (button) && Time.time > nextHeal && !this.GetComponent<InkAbilityController> ().doingAbility) 
		{
			anim.Play(animName);
			animHub.Play(animNameHub);
			ink.GetComponent<PincelColorController> ().changeColor ("green");

			//Rotación del personaje hacia el ratón si se esta utilizando el mando y el ratón
			GetComponent<InkMouseRotation> ().RotationMouse();

			//Generación del Gameobject/Sprite de la habilidad de fuego
			Transform rotation = Spawner.transform;
			GameObject clone = Instantiate (Sprite, new Vector3(Spawner.transform.position.x, Spawner.transform.position.y + 0.4f, Spawner.transform.position.z), rotation.rotation);
			clone.transform.parent = Spawner.transform;
			clone.GetComponent<DestroyByTime> ().lifetime = timeLife;

			GameObject clone2 = Instantiate (icon, iconSpawner.transform.position, rotation.rotation);
			clone2.transform.parent = iconSpawner.transform;
			clone2.GetComponent<DestroyByTime> ().lifetime = timeLife;

			//Inicializamos el timer que controla el tiempo entre habilidades
			nextHeal = Time.time + cd;
			timeHealing = Time.time + timeLife;
		}

		if (timeHealing > Time.time) {
			if (Global.Instance.life < 100) {
				Global.Instance.life += 10 * Time.deltaTime;
			}
			if (Global.Instance.life > 100) {
				Global.Instance.life = 100;
			}
		}

	}

}