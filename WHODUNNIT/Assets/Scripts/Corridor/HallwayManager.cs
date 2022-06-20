using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayManager : MonoBehaviour
{
    public List<Hallway> hallways;
    Hallway currentPiece, prevPiece;
    float timer = 0;

    private void Start()
    {
        foreach (Hallway hallway in hallways)
        {
            hallway.gameObject.SetActive(false);
        }

        currentPiece = Instantiate(hallways[0].gameObject).GetComponent<Hallway>();
        currentPiece.gameObject.SetActive(true);

    }



    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            timer = 0;
            MakeNewPiece();
        }
    }

    void MakeNewPiece()
    {
        int i = Random.Range(0, hallways.Count);

        Hallway newHallway = Instantiate(hallways[i].gameObject).GetComponent<Hallway>();
        newHallway.gameObject.SetActive(true);

        //end+start

        float newRot = currentPiece.transform.eulerAngles.y + (newHallway.startAngle - currentPiece.endAngle) + 180;
        newHallway.transform.eulerAngles = new Vector3(0, newRot, 0);

        Vector3 endPos = currentPiece.transform.TransformPoint(currentPiece.endAnchor);
        Vector3 startPos = newHallway.transform.TransformPoint(newHallway.startAnchor);
        Vector3 offset = endPos - startPos;
        newHallway.transform.position += offset;

        newHallway.gameObject.name = hallways[i].gameObject.name;

        if (prevPiece != null)
        {
            Destroy(prevPiece.gameObject);
        }

        prevPiece = currentPiece;
        currentPiece = newHallway;
    }
}
