using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButton : MonoBehaviour {
    public HoverButton hoverButton;
    public GreyscaleImage image;
    public bool IsLocked { get; protected set; }

    private void Start()
    {
        //Lock();
    }

    public void Lock()
    {
        hoverButton.interactable = false;
        image.greyscale = true;
    }

    public void Unlock()
    {
        hoverButton.interactable = true;
        image.greyscale = false;
    }
}
