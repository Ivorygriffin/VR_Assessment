using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableItem : MonoBehaviour
{
    public Material change;

    public void OnSelect()
    {
        GetComponent<MeshRenderer>().material = change;
    }
}
