using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class SelectEvent : UnityEvent
{
}

public class HoverButton : Button {
    public SelectEvent onSelect;
    public SelectEvent onDeselect;
    public SelectEvent onPointerEnter;
    public SelectEvent onPointerExit;

    public override void OnSelect(BaseEventData eventData)
    {
        onSelect.Invoke();
        base.OnSelect(eventData);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        onDeselect.Invoke();
        base.OnDeselect(eventData);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        onPointerEnter.Invoke();
        base.OnPointerEnter(eventData);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        onPointerExit.Invoke();
        base.OnPointerExit(eventData);
    }
}
