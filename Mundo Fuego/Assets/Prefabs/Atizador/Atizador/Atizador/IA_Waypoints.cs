using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Waypoints : MonoBehaviour {

    //public
    public bool gravity = true;
    public GameObject[] waypoints;
    public float velocidad;
    public GameObject pj;
    public float deteccion; //distancia a la que el enemigo ve al personaje
    public float velPerseguir;
    public int waypoint = 0;

    //private
    private Rigidbody rigid;

	// Use this for initialization
	void Start () {
        goWaypoint = true;
        rigid = GetComponentInParent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        //miramos la distancia con el personaje
        Vector3 distpj = pj.transform.position - transform.position;

        if (gravity)//si estamos sobre un plano ignoramos la componente y
        {
            distpj = new Vector3(distpj.x, 0, distpj.z);
        }

        //calculamos la distancia
        float auxdist = Mathf.Sqrt((distpj.x* distpj.x) + (distpj.y * distpj.y) + (distpj.z * distpj.z));

        if (auxdist < deteccion)
        {
            transform.LookAt(pj.transform.position);
            if (GoWaypoint(pj.transform.position, velPerseguir, pj.transform))
            {
                //cuando lleguemos al waypoint paramos
                goWaypoint = false;

                //usamos los scripts de comportamiento cuando lleguemos
                bool patron = false;
                MonoBehaviour[] waypointScripts = pj.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour script in waypointScripts)
                {
                    //si encuentra un script de comportamiento lo ejecuta
                    if (script.GetType().Name.Contains("Patron"))
                    {
                        patron = true;
                        script.enabled = true;
                    }
                }

                //sino encontramos ningun script pasamos al siguiente waypoint
                if (!patron)
                {
                    goWaypoint = true;
                }
            }
        }
        else
        {
            //activamos o desactivamos la gravedad
            rigid.useGravity = gravity;
            //calculamos la velocidad al waypoint sino asumiremos que es 0
            float velWay = 0;
            try
            {
                velWay = velocidad;
            }
            catch
            {
                velWay = 0;
            }

            //comprobamos si podemos ir al waypoint
            if (goWaypoint)
            {
                //comprobamos si podemos mover movemos el objeto al waypoint
                try
                {
                    //movemos al siguiente
                    if (GoWaypoint(waypoints[waypoint].transform.position, velWay, waypoints[waypoint].transform))
                    {
                        //cuando lleguemos al waypoint paramos
                        goWaypoint = false;

                        //usamos los scripts de comportamiento cuando lleguemos
                        bool patron = false;
                        MonoBehaviour[] waypointScripts = waypoints[waypoint].GetComponents<MonoBehaviour>();
                        foreach (MonoBehaviour script in waypointScripts)
                        {
                            //si encuentra un script de comportamiento lo ejecuta
                            if (script.GetType().Name.Contains("Patron"))
                            {
                                patron = true;
                                script.enabled = true;
                            }
                        }

                        //sino encontramos ningun script pasamos al siguiente waypoint
                        if (!patron)
                        {
                            goWaypoint = true;
                        }
                        //miramos si es el ultimo sino saltamos al siguiente
                        if (waypoint != waypoints.Length - 1)
                        {
                            waypoint++;
                        }
                        else
                        {
                            waypoint = 0;
                        }
                    }
                }
                catch
                {
                    //miramos si es el ultimo sino saltamos al siguiente
                    if (waypoint != waypoints.Length - 1)
                    {
                        waypoint++;
                    }
                    else
                    {
                        waypoint = 0;
                    }
                }
            }
        }
	}

    private bool GoWaypoint(Vector3 PosWaypoint, float vel, Transform objetivo)
    {
        //distancia entre el waypoint y el personaje
        Vector3 distWaypoint = PosWaypoint - transform.position;
        if (gravity)//si estamos sobre un plano ignoramos la componente y
        {
            distWaypoint = new Vector3(distWaypoint.x, 0, distWaypoint.z);
        }

        //miramos  si aun no ha llegado
        if ((Mathf.Abs(distWaypoint.x) > 0.2f || Mathf.Abs(distWaypoint.y) > 0.2f || Mathf.Abs(distWaypoint.z) > 0.2f))
        {
            distWaypoint.Normalize(); //normalizamos la distancia
            distWaypoint *= vel; //multiplicamos por la velocidad

            //movemos el objeto
            transform.Translate(distWaypoint * Time.deltaTime, Space.World);
            //devolvemos false
            return false;
        }
        return true;
    }

    private void girarObjetivo(Transform objetivo)
    {
        //buscamos la distancia
        Vector3 distance = transform.position - objetivo.position;
        //la normalizamos
        distance.Normalize();
        //front vector
        Vector3 frontal = transform.forward;

        frontal.Normalize();
        //prodducto escalar para sacar el angulo
        float anguloL = Vector3.Dot(-frontal, distance);

        //hacemos el acoseno y lo pasamos a radianes
        float angulo = Mathf.Acos(anguloL) * Mathf.Rad2Deg;

        transform.RotateAround(transform.position, Vector3.up, angle: -30 * Time.deltaTime);
    
        //float Angulo = Mathf.Abs(angulo);
    
        Debug.Log(angulo);
       
    }

    public bool goWaypoint { get; set; } //nos dice si podemos ir al waypoint
}
