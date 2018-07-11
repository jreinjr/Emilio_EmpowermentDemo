using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SphericalTransform : MonoBehaviour {

    public bool m_LookAtOrigin;
    public Vector3 m_origin;
    public float m_radius;
    [Range(-90, 90)] public float m_polar = 0;
    [Range(-180, 180)] public float m_azimuthal = 0;

    public static Vector3 ConvertSphericalToCartesian(Vector3 origin, float radius, float polar, float azimuthal)
    {
        polar *= Mathf.Deg2Rad;
        azimuthal *= Mathf.Deg2Rad;

        float x = origin.x + radius * Mathf.Sin(polar) * Mathf.Cos(azimuthal);
        float y = origin.y + radius * Mathf.Sin(azimuthal) * Mathf.Cos(polar);
        float z = origin.z + radius * Mathf.Cos(polar);

        return new Vector3(x, y, z);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = ConvertSphericalToCartesian(m_origin, m_radius, m_polar, m_azimuthal);

        if (m_LookAtOrigin)
            transform.rotation = Quaternion.LookRotation(transform.position - m_origin);
	}
}
