using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global Instance { get; private set; }

	public bool controller;

    public GameObject deathMessage; 

	public float life; 

    //lo usamos porque se ejecuta antes de que comience el juego
    void Awake()
    {
        life = 100;
        if(Instance == null)//miramos si la instancia es null
        {
            Instance = this;//asignamos a la instancia la clase
            DontDestroyOnLoad(gameObject);//le decimos que no destruya el objeto
        }
        else if(Instance != this)//miramos si la instancia esta asignada a alguien
        {
            Destroy(gameObject);//para no tener duplicados destruimos la que no necesitamos
        }
    }

    void Update()
    {
        if (deathMessage != null)
        {
            if (life <= 0.0f)
            {
                deathMessage.SetActive(true);
            }
        }
    }
}
