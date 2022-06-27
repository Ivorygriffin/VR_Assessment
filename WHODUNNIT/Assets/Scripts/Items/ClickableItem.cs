using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

[RequireComponent(typeof(XRSimpleInteractable))]
public class ClickableItem : MonoBehaviour
{
    public UnityEvent onClicked, onClickEnd;

    public void OnClicked()
    {
        onClicked?.Invoke();
    }

    public void OnClickEnd()
    {
        onClickEnd?.Invoke();
    }
}
