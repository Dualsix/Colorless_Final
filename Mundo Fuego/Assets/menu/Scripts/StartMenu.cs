using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
	
	public void PlayGame()
	{
		SceneManager.LoadScene(4);
        SceneManager.UnloadSceneAsync(0);
    }
	
	
}
