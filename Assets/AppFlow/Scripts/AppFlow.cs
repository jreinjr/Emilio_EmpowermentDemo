using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// AppFlow is used to transmit events between scenes.
/// It receives events from SceneFlow, opens the appropriate scene to handle the event,
/// closes the current scene and then rebroadcasts the event.
/// </summary>
public class AppFlow : MonoBehaviour {
    public static AppFlow instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitPersistentScene();
    }

    void InitPersistentScene()
    {
        // Loop through loaded scenes 
        bool appFlowLoaded = false;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == "AppFlow")
                appFlowLoaded = true;
        }
        // If AppFlow scene is not loaded, load it.
        if (appFlowLoaded == false)
            SceneManager.LoadSceneAsync("AppFlow", LoadSceneMode.Additive);
    }

    private void Update()
    {
        InitPersistentScene();
    }
}
