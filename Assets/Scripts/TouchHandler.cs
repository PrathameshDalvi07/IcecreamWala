using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static TouchHandler Instance { get; private set; }
    PointerEventData currentPointerEventData;
    public static Action<PointerEventData> OnTap;

    private void Start()
    {
        Instance = this;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentPointerEventData == null)
        {
            OnTap?.Invoke(eventData);
            currentPointerEventData = eventData;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (currentPointerEventData == eventData)
        {
            currentPointerEventData = null;
        }
    }
}
