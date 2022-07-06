using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayManager : MonoBehaviour
{
    public Hallway start;
    Hallway currentPiece, prevPiece, newPiece;
    float timer = 0;

    public static HallwayManager instance;
    public bool auto = false;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentPiece = Instantiate(start).GetComponent<Hallway>();
        currentPiece.gameObject.SetActive(true);
        newPiece = start;
    }

    private void Update()
    {
        if (auto)
        {
            timer += Time.deltaTime;

            if (timer > 1)
            {
                timer = 0;
                MakeNewPiece();
            }
        }
    }

    public void SetPrevPiece(Hallway prev)
    {
        prevPiece = prev;
    }

    public void SetCurrentHallway(Hallway current)
    {
        currentPiece = current;
    }

    public void SetNextHallway(Hallway next)
    {
        newPiece = next;
    }

    public void MakeNewPiece()
    {
        Hallway newHallway = Instantiate(newPiece.gameObject).GetComponent<Hallway>();
        newHallway.gameObject.SetActive(true);

        //end+start

        float newRot = currentPiece.transform.eulerAngles.y + (newHallway.startAngle - currentPiece.endAngle) + 180;
        newHallway.transform.eulerAngles = new Vector3(0, newRot, 0);

        Vector3 endPos = currentPiece.transform.TransformPoint(currentPiece.endAnchor);
        Vector3 startPos = newHallway.transform.TransformPoint(newHallway.startAnchor);
        Vector3 offset = endPos - startPos;
        newHallway.transform.position += offset;

        newHallway.gameObject.name = newPiece.gameObject.name;

        if (prevPiece != null)
        {
            Destroy(prevPiece.gameObject);
        }

        prevPiece = currentPiece;
        currentPiece = newHallway;
    }
}
