using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayMakerFSM))]
public class ReturnToMenu : MonoBehaviour {

    public PlayMakerFSM fsm;

    void Update () {
        if (OVRInput.GetUp(OVRInput.RawButton.Back) || OVRInput.GetUp(OVRInput.RawButton.Start))
        {
            fsm.SendEvent("Menu_Clicked");
        }
    }
}
