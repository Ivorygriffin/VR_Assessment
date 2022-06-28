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

    int playerLayer, defaultLayer;

    private void Start()
    {
        grabbable = GetComponent<GrabbableItemInteractable>();
        if (grabPoint != null) { grabbable.attachTransform = grabPoint; }

        foreach (Combine combination in combinations)
        {
            combination.result.SetActive(false);
        }

        playerLayer = LayerMask.NameToLayer("Player");
        defaultLayer = LayerMask.NameToLayer("Default");
    }

    public void Grab()
    {
        gameObject.layer = playerLayer;
    }

    public void OnSelect()
    {
        onSelect?.Invoke();
    }

    public void Release()
    {
        hand = null;
        gameObject.layer = defaultLayer;
    }

    public void ForceRelease(bool enable)
    {
        grabbable.DropItem();
        gameObject.SetActive(enable);
        if (hand != null) { hand.held = null; }
        hand = null;
    }
}


[System.Serializable]
public class Combine
{
    public GrabbableItem secondItem;
    public GameObject result;
    public UnityEvent eventOnCombine;
}
