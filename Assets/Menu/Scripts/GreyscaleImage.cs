using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(Image))]
public class GreyscaleImage : MonoBehaviour {

    public bool greyscale;
    bool _prevGreyscale;
    Image image;

    // Update is called once per frame
    void Update () {
        if (_prevGreyscale != greyscale)
        {
            GreyscaleChanged();
        }

        _prevGreyscale = greyscale;	
	}

    private void OnEnable()
    {
        Init();
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        image = GetComponent<Image>();

    }

    void GreyscaleChanged()
    {
        Material mat = Instantiate(image.material);
        if (greyscale)
            mat.SetFloat("_Greyscale", 1);
        else
            mat.SetFloat("_Greyscale", 0);
        image.material = mat;
    }
}
