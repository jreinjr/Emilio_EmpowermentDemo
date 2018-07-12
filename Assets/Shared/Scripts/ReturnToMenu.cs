using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayMakerFSM))]
public class ReturnToMenu : MonoBehaviour {

    PlayMakerFSM fsm;

    private void Start()
    {
        fsm = GameObject.Find("AppFlow").GetComponent<PlayMakerFSM>();
    }

    void Update () {
        if (OVRInput.GetUp(OVRInput.RawButton.Back) || OVRInput.GetUp(OVRInput.RawButton.Start))
        {
            fsm.SendEvent("Menu_Clicked");
        }
    }
}
