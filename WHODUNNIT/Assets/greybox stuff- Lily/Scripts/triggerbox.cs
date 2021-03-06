using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class triggerbox : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit, OnItemEnter;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OnEnter.Invoke();
        }
        if (other.tag == "Item")
        {
            OnItemEnter.Invoke();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Item")
        {
            OnExit.Invoke();    
        }
    }

}
