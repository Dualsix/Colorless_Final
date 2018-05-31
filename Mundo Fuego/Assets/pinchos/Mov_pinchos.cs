using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_pinchos : MonoBehaviour {
    //se tienen que agrupar los pinchos por grupos en un game object vacio
    //variables publicas
    public GameObject[] pinchos; //pinchos que se moveran
    public float delay; //tiempo que tarda en empezar a moverse al principio
    public float time_act;  //tiempo que estan activados
    public float time_des;  //tiempo que estan desactivados
    public float retraso; //tiempo entre los pinchos del mismo bloque
    //variables privadas
    private float timer_delay;
    private float timer_rest;
    private bool activos;
    private float rest;
    private float timer_retraso;

    // Use this for initialization
    void Start () {
        timer_delay = 0;
        timer_rest = rest + 1;
        activos = false;
        timer_retraso = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //sumamos tiempoa l delayh timer
        if (timer_delay < delay)
        {
            timer_delay += Time.deltaTime;
        }
        //empezamos la acción cuando el timer delay supera el delay estipulado
        if (timer_delay >= delay)
        {
            if (timer_rest < rest)
            {
                timer_rest += Time.deltaTime;
            }
            //ejecutamos la accion despues de haber esperado el tiempo de descanso entre acciones
            if (timer_rest >= rest)
            {
                //reiniciamos el timer
                timer_retraso = 0;
                //float aux = 0;
                //si estan activos los desactivamos
                if (activos)
                {
                    for(int i = 0; i < pinchos.Length;)
                    {
                        timer_retraso = Time.deltaTime;
                        //contamos el retraso
                        if ((timer_retraso) >= retraso)
                        {
                            pinchos[i].SetActive(false);
                            timer_retraso = 0;
                            //aux = timer_retraso;
                            i++;
                        }
                    }
                    rest = time_des;
                    activos = false;
                }
                //si estan desactivados los activamos
                else
                {
                    for (int i = 0; i < pinchos.Length;)
                    {
                        timer_retraso = Time.time;
                        //contamos el retraso
                        if ((timer_retraso) >= retraso)
                        {
                            pinchos[i].SetActive(true);
                            timer_retraso = 0;
                            //aux = timer_retraso;
                            i++;
                        }
                    }
                    rest = time_act;
                    activos = true;
                }
                //reiniciamos el tiemr del descanso
                timer_rest = 0;
            }
        }
	}
}
