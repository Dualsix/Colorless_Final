using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkMovement : MonoBehaviour {
	//----- Public -----
	//MOVEMENT
	public float forwardSpeed = 5.0f;   //velocidad hacia adelante
	public float backwardSpeed = 5.0f;      //velocidad hacia atras

	//ROTATION
	private GameObject rotationPlayer;

	//OTHERS
	public Animator anim;
	public string animName;

	public Vector3 velocity;   //creamos el vector de velocidad

	//----- Private -----
	//MOVEMENT
	private float h;    //Creamos la variable de movimiento horizontal
	private float v;    //Creamos La variable de movimiento verticaL


	void Start () {
		h = 0;
		v = 0;

		rotationPlayer = GameObject.FindGameObjectWithTag ("Rotation Player");
	}
		
	void FixedUpdate() {
		if (this.GetComponent<InkAbilityController>().movementEnable){
			h = Input.GetAxis("Horizontal");    //cojemos el eje horizontal de movimiento
			v = Input.GetAxis("Vertical");    //cojemos el eje vertical de movimiento

			makeVelocity (h, v);

			//Rotación del personaje si se está mirando hacia otro sitio 
			if (velocity != new Vector3 (0.0f, 0.0f, 0.0f)) {
				rotationPlayer.transform.forward = velocity.normalized;
			} else {
				anim.SetBool ("stop", true);
				anim.SetBool ("movement", false);
			}

			transform.localPosition += velocity * Time.fixedDeltaTime; //movemos el objeto
		}

	}

	void makeVelocity (float h, float v){
		velocity = new Vector3(h, 0, v); //llenamos el vecotr de velocidad

		if (v > 0.1 || h > 0.1)
		{       //movemos hacia delante en el eje vertical o horizontal
			velocity *= forwardSpeed;
			startMovement();
		}
		else if (v < -0.1 || h < -0.1)
		{     //movemos hacia atras en el eje vertical o horizontal
			velocity *= backwardSpeed;
			startMovement ();
		}
	}

	void startMovement(){
		anim.SetBool ("movement", true);
		anim.SetBool ("stop", false);
	}
}
