using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetLife : MonoBehaviour {
    public GameObject global;

	void Start () {
        global.GetComponent<Global>().life = 100;
        Destroy(this);
	}
}
