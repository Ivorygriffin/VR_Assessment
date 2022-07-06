using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenAndClosed : MonoBehaviour
{
    public Animator door;

    public float doorTimeToClose;



    public void OnTriggerEnter(Collider other)
    {
        door.SetTrigger("open");
    }



    public void OnTriggerExit(Collider other)
    {
        StartCoroutine(DoorClosed());


    }


    public IEnumerator DoorClosed()
    {
        yield return new WaitForSeconds(doorTimeToClose);


        door.SetTrigger("closed");

        

    }



}
