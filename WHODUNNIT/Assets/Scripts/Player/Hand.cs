using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Item held;

    public void Grab(Item item)
    {
        held = item;
    }

    public void Release()
    {
        held = null;
    }
}
