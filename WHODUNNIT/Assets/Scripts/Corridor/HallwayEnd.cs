using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayEnd : MonoBehaviour
{
    bool used = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !used)
        {
            HallwayManager.instance.MakeNewPiece();
            used = true;

        }
    }
}
