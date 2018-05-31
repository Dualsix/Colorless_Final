using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Neko : MonoBehaviour {
    //variables publics
    public GameObject[] waypoints;
    public GameObject portal;
    public GameObject esfera;

    //variables publics
    private int waypoint;
    private Transform pj;
    private bool atack;
    private float timer;
    private float distance;
    private int rand;
    private bool first;
    private float timer_portal;
    private int cont;
    private Animator anim;
    private bool alternar;

	// Use this for initialization
	void Start () {
        pj = GameObject.FindGameObjectWithTag("Player GameObject").transform;
        waypoint = 0;
        atack = false;
        distance = Vector3.Distance(pj.position, transform.position);
        first = true;
        timer_portal = 0;
        cont = 0;
        alternar = true;
        anim = anim = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //activarlo cuando este cerca
       // if (distance < 20)
        //{
            timer += Time.deltaTime;
            //apuntamos al prota

            transform.LookAt(pj);
            anim.SetBool("Attack", false);
            anim.SetBool("Teleport", false);
            //ponemos un timer de un segundo entre atacar ejecutar el teleport
            if (timer >= 2)
            {
                //entramos a atacar 
                if (atack)
                {
                    Neko_atack();
                }
                else
                {
                    Neko_teleport();
                }
            }
       // }
	}

    private void Neko_atack()
    {
        anim.SetBool("Attack", true);
        GameObject beam = Instantiate(esfera, esfera.transform.position, esfera.transform.rotation);
        beam.SetActive(true);
        atack = false;
        timer = 0;
    }

    private void Neko_teleport()
    {
        if (first)
        {
            rand = Random.Range(5, 10);
            first = false;
        }
        timer_portal += Time.deltaTime;
        if(rand > 0)
        {
            if (rand > 1)
            {
                if (timer_portal > 0.5)
                {
                    //a la mitad del rand tiramos otra bola
                    if (rand == 5)
                    {
                        anim.SetBool("Attack", true);
                        GameObject beam = Instantiate(esfera, esfera.transform.position, esfera.transform.rotation);
                        beam.SetActive(true);
                        atack = false;
                    }
                    GameObject port = Instantiate(portal, waypoints[waypoint].transform.position, portal.transform.rotation);
                    port.SetActive(true);
                    waypoint++;
                    if(waypoint >= waypoints.Length)
                    {
                        waypoint = 0;
                    }
                    rand--;
                    timer_portal = 0;
                }
            }
            if(rand == 1)
            {
                if(timer_portal > 0.5)
                {
                    anim.SetBool("Teleport", true);
                    GameObject port = Instantiate(portal, waypoints[waypoint].transform.position, portal.transform.rotation);
                    port.SetActive(true);
                    //aumentamos la vida del ultimo para que se vea que es alli donde va el gato
                    port.GetComponent<DestroyByTime>().lifetime = 2;
                    alternar = false;
                    timer_portal = 0;
                    rand--;
                }
            }
        }
        //pasamos a modo de ataque
        if(rand == 0)
        {
            timer_portal += Time.deltaTime;
            //esperamos un segundo y medio para teltransportarnos
            if (timer_portal > 1.5)
            {
                transform.position = waypoints[waypoint].transform.position;
                atack = true;
                first = true;
                timer = 0;
            }
        }
    }
}
