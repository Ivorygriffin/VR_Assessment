using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Vector2 winningLocalPos = new Vector2(0.5f, -2);
    public PuzzleManager manager;
    private void Update()
    {
        if (manager.GetWin()) { return; }
        Vector3 winPos = new Vector3(winningLocalPos.x, winningLocalPos.y, transform.localPosition.z);
        if (Vector3.Distance(transform.localPosition, winPos) < 0.3f)
        {
            manager.Win();
        }
    }
}
