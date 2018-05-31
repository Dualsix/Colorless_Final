using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkBasicAttack : MonoBehaviour 
{ 
	
	public float cd_attack; //Tiempo entre ataques.
	public float timeSpriteAttack;  //Tiempo que el sprite del ataque esta activo.

	public GameObject attackSprite; //Prefab/Sprite de ataque.
	public GameObject basicAttackSpawner; //GameObject que genera el sprite, dentro del player.

	private float nextAttack, stopSprite; //Timers auxiliares
	private Component abilityController; 
	private bool doingAttack; 

	public Animator anim;
	public string animName;

	void Start () 
	{
		stopSprite = 0;
		doingAttack = false; 
	}

	void Update () {
		if (Input.GetButtonDown("Fire1") && Time.time > nextAttack && !this.GetComponent<InkAbilityController> ().doingAbility)
		{
			anim.Play(animName);

			//Rotación del personaje hacia el ratón si se esta utilizando el mando y el ratón
			GetComponent<InkMouseRotation> ().RotationMouse(); 

			//Generación del Gameobject/Sprite del ataque
			Transform rotation = basicAttackSpawner.transform;
			rotation.localRotation = Quaternion.Euler(90.0f, 90.0f, 0.0f);
			GameObject clone = Instantiate (attackSprite, new Vector3(basicAttackSpawner.transform.position.x, basicAttackSpawner.transform.position.y + 0.4f, basicAttackSpawner.transform.position.z), rotation.rotation);
			clone.transform.parent = basicAttackSpawner.transform;
			clone.GetComponent<DestroyByTime> ().lifetime = timeSpriteAttack;

			//Inicializamos los timers que controlan el tiempo entre ataques y el tiempo que el sprite esta activo
			stopSprite = Time.time + timeSpriteAttack;
			nextAttack = Time.time + cd_attack;

			this.GetComponent<InkAbilityController> ().doingAbility = true;
			this.GetComponent<InkAbilityController> ().movementEnable = false;
			doingAttack = true; 
		}

		//Cuando el Sprite se "muere" podemos utilizar otras habilidades
		if (stopSprite < Time.time && doingAttack) 
		{
			this.GetComponent<InkAbilityController> ().doingAbility = false;
			this.GetComponent<InkAbilityController> ().movementEnable = true;

			doingAttack = false; 
		}
	}
}
