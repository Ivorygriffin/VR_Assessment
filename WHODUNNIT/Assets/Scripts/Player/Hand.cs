using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GrabbableItem held;

    public void Grab(GrabbableItem item)
    {
        held = item;
        held.hand = this;
    }

    public void Release()
    {
        held.hand = null;
        held = null;
    }
}
