using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GrabbableItem held;

    public void Grab(GrabbableItem item)
    {
        Audio.instance.Grab();
        item.Grab();
        held = item;
        held.hand = this;
    }

    public void Release()
    {
        if (held == null) { return; }
        Audio.instance.Drop();
        held.Release();
        held = null;
    }
}
