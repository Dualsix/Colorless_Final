using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class resetLevel : MonoBehaviour {
    public float timer = 0;
    public GameObject global;
    public int level;

    private float end;
    private GameObject player;
    

    void Start() {
        end = Time.time + timer;
            
        player= GameObject.FindGameObjectWithTag("Player GameObject");

        if (player == null)
        {
            Debug.Log("No se ha encontrado al jugador");
            this.gameObject.SetActive(false);
        }
        else
        {
            player.GetComponent<InkAbilityController>().movementEnable = false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (end < Time.time)
        {
            global.GetComponent<Global>().life = 100;
            SceneManager.UnloadSceneAsync(level);
            SceneManager.LoadScene(level);
        }
    }
}
