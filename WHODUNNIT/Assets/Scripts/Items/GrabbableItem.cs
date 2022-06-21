using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableItem : MonoBehaviour
{
    public Item item;
    public Transform grabPoint;
    public UnityEvent onSelect;

    private void Start()
    {
        if (grabPoint != null) { GetComponent<GrabbableItemInteractable>().attachTransform = grabPoint; }
    }

    public void OnSelect()
    {
        onSelect?.Invoke();
    }


}
