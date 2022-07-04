using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenAndClosed : MonoBehaviour
{
    public Animator door;

    public bool opening;

    public void OnTriggerEnter(Collider other)
    {
        door.SetTrigger("open");
    }

    public void OnTriggerStay(Collider other)
    {
        opening = true;
    }


    public void OnTriggerExit(Collider other)
    {
        StartCoroutine(DoorClosed());

        opening = false;
    }


    public IEnumerator DoorClosed()
    {
        yield return new WaitForSeconds(15f);


        if(opening == false)
        {
            door.SetTrigger("closed");


        }
        

    }



}
