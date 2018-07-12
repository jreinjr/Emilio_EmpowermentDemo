using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VRTK;

[Serializable]
public class RadialCursorEvent : UnityEvent{}

public class RadialCursorTimer : MonoBehaviour {

    [SerializeField] private float m_SelectionDuration = 2f;
    [SerializeField] private Image m_Image;

    public RadialCursorEvent OnSelectionComplete;

    private Coroutine m_SelectionFillRoutine;
    private bool m_RadialFilled;

    public float SelectionDuration { get { return m_SelectionDuration; } }

    private void Start()
    {
        m_Image.fillAmount = 0f;
    }

    public void StartTimer()
    {
        StopTimer();
        m_SelectionFillRoutine = StartCoroutine(FillSelectionRadial());
    }

    public void StopTimer()
    {
        if (m_SelectionFillRoutine != null)
            StopCoroutine(m_SelectionFillRoutine);

        m_Image.fillAmount = 0f;
    }

    private IEnumerator FillSelectionRadial()
    {
        // Create a timer and reset the fill amount
        float timer = 0f;
        m_Image.fillAmount = 0f;

        // This loop is executed once per frame until the timer exceeds the duration
        while (timer < m_SelectionDuration)
        {
            // The fill amount requires a value from 0 to 1 so we normalize the timer
            m_Image.fillAmount = timer / m_SelectionDuration;

            // Increase the timer between frames and wait for the next frame
            timer += Time.deltaTime;
            yield return null;
        }

        // When the loop is finished set the fill amount to be full
        m_Image.fillAmount = 1f;

        // If anything is subscribed to OnSelectionComplete call it
        if (OnSelectionComplete != null)
            OnSelectionComplete.Invoke();
    }
}
