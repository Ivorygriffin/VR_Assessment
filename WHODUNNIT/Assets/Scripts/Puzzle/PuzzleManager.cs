using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public UnityEvent onWin;
    public static PuzzleManager instance;
    bool win = false;
    private void Awake()
    {
        instance = this;
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
