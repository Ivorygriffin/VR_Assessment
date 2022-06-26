using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsController : MonoBehaviour
{
    public Hand left, right;
    Transform mainCam;

    private void Start()
    {
        mainCam = Camera.main.transform;
    }

    private void Update()
    {
        if (left.held != null && right.held != null)
        {
            if (Vector3.Distance(left.transform.position, right.transform.position) < 0.2f)
            {
                if (!Combine(left.held, right.held)) { Combine(right.held, left.held); }
            }
        }
    }


    bool Combine(GrabbableItem item1, GrabbableItem item2)
    {
        foreach (Combine combination in item1.combinations)
        {
            if (combination.secondItem == item2)
            {
                combination.result.transform.position = transform.position + mainCam.forward;
                combination.result.SetActive(true);

                item1.Release();
                item2.Release();
                return true;
            }
        }
        return false;
    }
}
