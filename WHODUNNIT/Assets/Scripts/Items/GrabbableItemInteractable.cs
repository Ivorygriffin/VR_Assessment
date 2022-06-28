using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableItemInteractable : XRGrabInteractable
{
    SelectEnterEventArgs args;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        this.args = args;
        Hand hand = args.interactorObject.transform.GetComponent<Hand>();
        GrabbableItem item = args.interactableObject.transform.GetComponent<GrabbableItem>();
        hand.Grab(item);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        Hand hand = args.interactorObject.transform.GetComponent<Hand>();
        hand.Release();
    }

    protected override void OnActivated(ActivateEventArgs args)
    {
        GrabbableItem item = args.interactableObject.transform.GetComponent<GrabbableItem>();

        ItemInteractionManager.instance.ClickWithItem(item);
    }

    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        GrabbableItem item = args.interactableObject.transform.GetComponent<GrabbableItem>();

        ItemInteractionManager.instance.ReleaseWithItem(item);
    }

    public void DropItem()
    {
        interactorsSelecting.Remove(args.interactorObject);
        Drop();
    }
}
