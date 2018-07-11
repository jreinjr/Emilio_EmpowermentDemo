using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppFlow : MonoBehaviour {

	void Start () {

        if (GameObject.Find("AppFlow") != this.gameObject)
            Destroy(this.gameObject);

        DontDestroyOnLoad(gameObject);

        bool appFlowLoaded = false;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == "AppFlow")
                appFlowLoaded = true;
        }
        if (appFlowLoaded == false)
            SceneManager.LoadSceneAsync("AppFlow", LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
