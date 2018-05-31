using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkMouseRotation : MonoBehaviour {
	private int floorMask;
	private float camRayLength = 100f;
	private RaycastHit hit; //Creamos el raycasthit con la informacion de los choques

	private GameObject rotationPlayer;

	void Start () 
	{ 
		rotationPlayer = GameObject.FindGameObjectWithTag ("Rotation Player");
		floorMask = LayerMask.GetMask("Raycast Layer");
	}
		
	//Rotación del personaje cuando se utiliza ratón y se realiza un "dash"
	public void RotationMouse()
	{
		if (!Global.Instance.controller) 
		{
			Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

			RaycastHit floorHit;

			if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
			{
				Vector3 playerToMouse = floorHit.point;
				playerToMouse.y= rotationPlayer.transform.position.y;
				rotationPlayer.transform.LookAt(playerToMouse);
			}
		}
	}
}
