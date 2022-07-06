using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStart : MonoBehaviour
{
    public UnityEvent OnStart;


    public void Start()
    {
        OnStart?.Invoke();
    }



}
