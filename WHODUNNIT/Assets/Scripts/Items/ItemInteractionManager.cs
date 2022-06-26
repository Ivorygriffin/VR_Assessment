using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractionManager : MonoBehaviour
{
    public static ItemInteractionManager instance;
    int layerMask;

    private void Awake()
    {
        instance = this;
        layerMask = LayerMask.GetMask("Interactable");
    }

    public void ClickWithItem(GrabbableItem item)
    {
        Hand hand = item.hand;

        if (Physics.Raycast(hand.transform.position, hand.transform.forward, out RaycastHit hit, 10, layerMask))
        {
            InteractWithItemEvents itemEvents = hit.collider.GetComponent<InteractWithItemEvents>();
            if (itemEvents != null)
            {
                itemEvents.OnInteract(hand);
            }
        }
    }

    public void ReleaseWithItem(GrabbableItem item)
    {
        Hand hand = item.hand;

        if (Physics.Raycast(hand.transform.position, hand.transform.forward, out RaycastHit hit, 10, layerMask))
        {
            InteractWithItemEvents itemEvents = hit.collider.GetComponent<InteractWithItemEvents>();
            if (itemEvents != null)
            {
                itemEvents.OnRelease(hand);
            }
        }
    }
}
