using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttackMovement : MonoBehaviour {
	public float velocity;

	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * velocity);
	}
}
