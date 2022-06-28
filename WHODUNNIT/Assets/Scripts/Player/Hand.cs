using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GrabbableItem held;

    public void Grab(GrabbableItem item)
    {
        item.Grab();
        held = item;
        held.hand = this;
    }

    public void Release()
    {
        held.Release();
        held = null;
    }
}
