using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractWithItemEvents : MonoBehaviour
{
    public List<ItemInteract> onAPressed;
    public List<ItemInteract> onAReleased;

    public void OnInteract(Hand hand)
    {
        foreach (ItemInteract i in onAPressed)
        {
            if (i.item == hand.held)
            {
                i.onInteract?.Invoke();
            }
        }
    }

    public void OnRelease(Hand hand)
    {
        foreach (ItemInteract i in onAReleased)
        {
            if (i.item == hand.held)
            {
                i.onInteract?.Invoke();
            }
        }
    }
}


[System.Serializable]
public class ItemInteract
{
    public GrabbableItem item;
    public UnityEvent onInteract;
}
