using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class checkcondtions : MonoBehaviour
{
    public UnityEvent OnComplete;
    public bool condition1, condition2, condition3;

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
    } 
    public void Set2True()
    {
        condition2 = true;
    }   
    public void Set3True()
    {
        condition3 = true;
    }
}
