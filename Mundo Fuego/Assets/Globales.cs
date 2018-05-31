using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Globales : MonoBehaviour
{
    //public
    public static Globales Instance { get; private set; }
    public static bool gato;
    public static bool fire;

    //private

    void Awake()
    {
        if (Instance == null)//miramos si la instancia es null
        {
            Instance = this;//asignamos a la instancia la clase
            DontDestroyOnLoad(gameObject);//le decimos que no destruya el objeto
        }
        else if (Instance != this)//miramos si la instancia esta asignada a alguien
        {
            Destroy(gameObject);//para no tener duplicados destruimos la que no necesitamos
        }
    }
    private void Start()
    {
        gato = false;
        fire = false;
    }
}
