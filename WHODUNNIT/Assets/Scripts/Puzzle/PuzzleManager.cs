using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public UnityEvent onWin;
    bool win = false;
    public Transform location; 
    private void Start()
    {
       /* transform.position = location.position;
        transform.rotation = location.rotation;*/
    }
    public void Win()
    {
        onWin?.Invoke();
        win = true;
        Debug.Log("win");
    }

    public bool GetWin()
    {
        return win;
    }
}
