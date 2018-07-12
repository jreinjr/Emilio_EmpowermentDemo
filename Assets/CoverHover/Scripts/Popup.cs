using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Popup : MonoBehaviour {

    public UnityEvent ClosePopup;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RTouchpad) || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            if (ClosePopup != null)
                ClosePopup.Invoke();
        }
    }
}
