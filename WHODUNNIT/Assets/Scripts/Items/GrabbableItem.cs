using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(GrabbableItemInteractable))]
public class GrabbableItem : MonoBehaviour
{
    public Transform grabPoint;
    public UnityEvent onSelect;

    public List<Combine> combinations;
    GrabbableItemInteractable grabbable;
    public Hand hand;

    private void Start()
    {
        grabbable = GetComponent<GrabbableItemInteractable>();
        if (grabPoint != null) { grabbable.attachTransform = grabPoint; }

        foreach (Combine combination in combinations)
        {
            combination.result.SetActive(false);
        }
    }

    public void OnSelect()
    {
        onSelect?.Invoke();
    }

    public void Release()
    {

    }
}


[System.Serializable]
public class Combine
{
    public GrabbableItem secondItem;
    public GameObject result;
    public UnityEvent eventOnCombine;
}
