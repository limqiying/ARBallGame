using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SuperpowerController: MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool ispressed;
    public bool IsPressed
        {   get
            {
                return ispressed;
            }
        }

    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
}