using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class checkcondtions : MonoBehaviour
{
    public UnityEvent OnComplete;
    public bool condition1, condition2, condition3;

    public GameObject debugMarker1;
    public GameObject debugMarker2;
    public GameObject debugMarker3;

    private void Start()
    {
        if (debugMarker1)
            debugMarker1.SetActive(false);
        if (debugMarker2)
            debugMarker2.SetActive(false);
        if (debugMarker3)
            debugMarker3.SetActive(false);
    }
    void Update()
    {
        CheckConditionsMet();
  
    }

    public void CheckConditionsMet()
    {
        if (condition1 == true && condition2 == true && condition3 == true)
        {
            OnComplete.Invoke();
            
        }
    }

    public void Set1True()
    {
        condition1 = true;
        if (debugMarker1)
            debugMarker1.SetActive(true);
    } 
    public void Set2True()
    {
        condition2 = true;
        if (debugMarker2)
            debugMarker2.SetActive(true);
    }   
    public void Set3True()
    {
        condition3 = true;
        if (debugMarker3)
            debugMarker3.SetActive(true);
    }
}
