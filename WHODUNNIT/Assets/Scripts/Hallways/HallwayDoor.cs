using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayDoor : Hallway
{
    public int ID;
    bool used = false;
    public Hallway parent;

    HallwayDoor[] doors;

    private void Start()
    {
        doors = transform.parent.gameObject.GetComponentsInChildren<HallwayDoor>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !used)
        {
            HallwayPuzzle.instance.GoThroughDoor(ID, this, parent);
            used = true;
            foreach (HallwayDoor door in doors)
            {
                door.SetUsed(true);
            }
        }
    }

    public void SetUsed(bool used)
    {
        this.used = used;
    }
}
