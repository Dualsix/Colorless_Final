using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIHieloController : MonoBehaviour {

    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Fire4"))
        {
			anim.Play ("HieloCD");
        }
    }
}
