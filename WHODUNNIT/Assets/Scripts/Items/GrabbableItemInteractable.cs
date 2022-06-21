using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableItemInteractable : XRGrabInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        Hand hand = args.interactorObject.transform.GetComponent<Hand>();
        GrabbableItem item = args.interactableObject.transform.GetComponent<GrabbableItem>();

        hand.Grab(item.item);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        Hand hand = args.interactorObject.transform.GetComponent<Hand>();
        hand.Release();
    }
}
