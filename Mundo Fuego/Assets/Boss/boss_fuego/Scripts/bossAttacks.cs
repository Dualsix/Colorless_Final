using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class bossAttacks : MonoBehaviour {
	public bool damaged = false; 
	public bool inmunidad = false; 
	public int life; 
	public GameObject[] zones;
	public GameObject barrier; 
	public Transform player; 
	public Animator anim; 
	public GameObject spawner1; 
	public GameObject spawner2; 
	public float nextAttack;

	private float timer; 
	private float chargeTp = 0; 
	private bool doingTp = false; 
	public bool isDoingAttack = false; 

	private int cout1 = 0;
	private int cout2 = 0;

	private int actualZone = 0;

    private void Start()
    {
        GameObject obj_player = GameObject.Find("Ink");

        if(obj_player == null) {

            Debug.Log("No se ha encontrado al jugador");
            this.gameObject.SetActive(false);
        }
        else
        {
            player = obj_player.transform;
        }
    }


    void Update () {
		if (life == 0) {
			Destroy (gameObject);
			SceneManager.LoadScene(0);

		} else {
			randomAttack ();
			if (damaged) {
				chargeTp = 2.0f + Time.time;
				doingTp = true; 
				inmunidad = true;
				damaged = false; 
				GameObject clone = Instantiate (barrier, transform.position, transform.rotation);
				clone.GetComponent<DestroyByTime> ().lifetime = 2.0f;
				anim.Play ("boss_fuego_attack2");
			}
			if (!inmunidad && timer < Time.time) {
				isDoingAttack = false; 
			}
		}

		if (Time.time > chargeTp && doingTp) {
			doingTp = false; 
			teleport (); 
			inmunidad = false;
		}
	}

	void teleport(){
		int next = 0;
		do{
			next = Random.Range (0, 5);
		}while (next == actualZone);
		actualZone = next; 
		transform.position = zones [actualZone].transform.position;
	}

	void randomAttack(){
		Vector3 position = player.position;
		position.y = transform.position.y;
		transform.LookAt(position);

		if (!isDoingAttack) {
			int random = Random.Range (0, 5);
			if (random < 3 && cout1 < 3 || cout1 < 3 && cout2 == 1) {
				anim.Play ("boss_fuego_attack"); 
				cout1++;
				cout2 = 0;
				spawner1.GetComponent<bossSpawner_1> ().enabled = true; 
			}
			else{
				anim.Play ("boss_fuego_attack2"); 
				cout1 = 0; 
				cout2++;
				spawner2.GetComponent<bossSpawner_2> ().enabled = true; 
			}
			isDoingAttack = true; 
			timer = Time.time + nextAttack;
		}
	}
}
