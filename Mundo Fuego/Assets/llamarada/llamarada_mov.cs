using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llamarada_mov : MonoBehaviour {
    //se tienen que agrupar las llamaradas por grupos si kieres que s emuevan a la vez la animación del fuego dura un segundo  tener en cuenta al poner los timers
    //variables publicas
    public GameObject llamas; //lamarada
    public float delay; //tiempo que tarda en empezar a moverse al principio
    public float time_act;  //tiempo que estan activados, debe ser multiplo de un segundo
    public float time_des;  //tiempo que estan desactivados
    //variables privadas
    private float timer_delay;
    private float timer_rest;
    private bool activos;
    private float rest;

    // Use this for initialization
    void Start()
    {
        timer_delay = 0;
        timer_rest = rest + 1;
        activos = false;
    }

    // Update is called once per frame
    void Update()
    {
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
                //si estan activos los desactivamos
                if (activos)
                {
                    llamas.SetActive(false);
                    rest = time_des;
                    activos = false;
                }
                //si estan desactivados los activamos
                else
                {
                    llamas.SetActive(true);
                    rest = time_act;
                    activos = true;
                }
                //reiniciamos el timer del descanso
                timer_rest = 0;
            }
        }
    }
}
