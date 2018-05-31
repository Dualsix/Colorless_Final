using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkStrongAttack : MonoBehaviour {
	public float cd_attack; //Tiempo entre ataques.
	public float timeSpriteAttack;  //Tiempo que el sprite del ataque esta activo.
	public float timeCharging; //Tiempo máximo que el jugador puede cargar la habilidads

	public GameObject attackSprite; //Prefab/Sprite de ataque.
	public GameObject fullAttackSprite; //Prefab/Sprite de ataque.
	public GameObject strongAttackSpawner; //GameObject que genera el sprite, dentro del player.


	private float nextAttack, stopSprite; //Timers auxiliares
	public float power; 
	private float charging; 
	private bool doingStrong;
	private bool endStrong; 

	void Start () 
	{
		stopSprite = 0;
		doingStrong = false; 
		charging = -1; 
		endStrong = false; 
	}

	void Update () {
		if (Input.GetButtonDown ("Fire2") && Time.time > nextAttack && !this.GetComponent<InkAbilityController> ().doingAbility) {
			//Rotación del personaje hacia el ratón si se esta utilizando el mando y el ratón
			GetComponent<InkMouseRotation> ().RotationMouse (); 

			charging = Time.time + timeCharging; 

			this.GetComponent<InkAbilityController> ().doingAbility = true;
			this.GetComponent<InkAbilityController> ().movementEnable = false;

			doingStrong = true; 
		}

		if (charging > Time.time && doingStrong) {
			power += 10 * Time.deltaTime; 
			if (Input.GetButtonUp ("Fire2")) {
				//Generación del Gameobject/Sprite del ataque
				Transform rotation = strongAttackSpawner.transform;
				rotation.localRotation = Quaternion.Euler (90.0f, 90.0f, 0.0f);
				GameObject clone = Instantiate (attackSprite, new Vector3 (strongAttackSpawner.transform.position.x, strongAttackSpawner.transform.position.y + 0.4f, strongAttackSpawner.transform.position.z), rotation.rotation);
				clone.transform.parent = strongAttackSpawner.transform;
				clone.GetComponent<DestroyByTime> ().lifetime = timeSpriteAttack;

				//Inicializamos los timers que controlan el tiempo entre ataques y el tiempo que el sprite esta activo
				stopSprite = Time.time + timeSpriteAttack;
				nextAttack = Time.time + cd_attack;

				endStrong = true; 
				doingStrong = false;
			}
		}

		if (charging < Time.time && doingStrong ) {
			//Generación del Gameobject/Sprite del ataque
			Transform rotation = strongAttackSpawner.transform;
			rotation.localRotation = Quaternion.Euler (90.0f, 90.0f, 0.0f);
			GameObject clone = Instantiate (fullAttackSprite, new Vector3 (strongAttackSpawner.transform.position.x, strongAttackSpawner.transform.position.y + 0.4f, strongAttackSpawner.transform.position.z), rotation.rotation);
			clone.transform.parent = strongAttackSpawner.transform;
			clone.GetComponent<DestroyByTime> ().lifetime = timeSpriteAttack;

			//Inicializamos los timers que controlan el tiempo entre ataques y el tiempo que el sprite esta activo
			stopSprite = Time.time + timeSpriteAttack;
			nextAttack = Time.time + cd_attack;

			doingStrong = false;
			endStrong = true; 
		}

		if (Time.time > stopSprite & endStrong) {
			this.GetComponent<InkAbilityController> ().doingAbility = false;
			this.GetComponent<InkAbilityController> ().movementEnable = true;

			endStrong = false;
			charging = 0;
			power = 0;
		}
	}
}
