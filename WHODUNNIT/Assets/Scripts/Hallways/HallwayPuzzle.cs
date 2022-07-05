using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayPuzzle : MonoBehaviour
{
    public Hallway mainHallway, nextHallway;
    public int key;
    int[] keys;
    public static HallwayPuzzle instance;
    int index = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        keys = new int[3];
        SetKey();
    }

    public void SetKey(int key)
    {
        this.key = key;
        SetKey();
    }

    void SetKey()
    {
        string k = key.ToString();
        for (int c = 0; c < 3; c++)
        {
            keys[c] = c < k.Length ? int.Parse(k[c].ToString()) : 0;
        }
    }

    public void GoThroughDoor(int door, Hallway hallway, Hallway parent)
    {
        if (door == keys[index])
        {
            index++;
        }
        else
        {
            index = door == keys[0] ? 1 : 0;
        }

        HallwayManager.instance.SetCurrentHallway(hallway);

        if (index >= 3)
        {
            HallwayManager.instance.SetNextHallway(nextHallway);
            index = 0;
        }
        else
        {
            HallwayManager.instance.SetNextHallway(mainHallway);
        }

        HallwayManager.instance.MakeNewPiece();
        HallwayManager.instance.SetPrevPiece(parent);

    }
    public void SetWinHallway(Hallway hallway)
    {
        nextHallway = hallway;
    }
}
