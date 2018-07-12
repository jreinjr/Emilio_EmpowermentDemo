using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PlayMaker;

public class LoadOnStartup : MonoBehaviour {
    public UnityEvent OnStartup;

    public PlayMakerFSM AppFlow;

    private void Start()
    {
        if (AppFlow.FsmVariables.GetFsmBool("startup").Value)
        {
            OnStartup.Invoke();
            AppFlow.FsmVariables.GetFsmBool("startup").Value = false;
        }
    }
}
