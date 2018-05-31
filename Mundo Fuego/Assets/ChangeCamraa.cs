using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamraa : MonoBehaviour {
    //public variables
    public GameObject stalker;
    public GameObject zenital;
    public GameObject[] sprites;
    public GameObject[] cilindros;

    //private variables
    private bool stay;

	// Use this for initialization
	void Start () {
        stay = false;
    }
	
	// Update is called once per frame
	void Update () {
        //if (stay)
        //{
        //    for (int i = 0; i < sprites.Length; i++)
        //    {
        //        sprites[i].GetComponent<SpriteRenderer>().enabled = false;
        //    }
        //    for (int i = 0; i < cilindros.Length; i++)
        //    {
        //        cilindros[i].GetComponent<MeshRenderer>().enabled = false;
        //    }
        //}
        //else
        //{
        //    for (int i = 0; i < sprites.Length; i++)
        //    {
        //        sprites[i].GetComponent<SpriteRenderer>().enabled = true;
        //    }
        //    for (int i = 0; i < cilindros.Length; i++)
        //    {
        //        cilindros[i].GetComponent<MeshRenderer>().enabled = true;
        //    }
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Trigger Player") {
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].GetComponent<SpriteRenderer>().enabled = false;
            }
            for (int i = 0; i < cilindros.Length; i++)
            {
                cilindros[i].GetComponent<MeshRenderer>().enabled = false;
            }
            zenital.SetActive(true);
           stay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Trigger Player")
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].GetComponent<SpriteRenderer>().enabled = true;
            }
            for (int i = 0; i < cilindros.Length; i++)
            {
                cilindros[i].GetComponent<MeshRenderer>().enabled = true;
            }
            stay = false;
            zenital.SetActive(false);
        }
    }
}
