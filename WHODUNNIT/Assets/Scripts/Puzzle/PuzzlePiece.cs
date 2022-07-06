/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PuzzlePieceInteractable))]
public class PuzzlePiece : MonoBehaviour
{
    public Vector2Int size;
    public bool horizontal, vertical;

    Vector3 targetPos;

    public Transform main;
    public GameObject grid;

    bool selected = false;
    Transform hand;
    Vector3 contactPos;

    int interactableMask, defaultMask;
    Vector2 upperBound, lowerBound;

    BoxCollider col;
    public PuzzleManager manager;

    private void Awake()
    {
        interactableMask = LayerMask.GetMask("Interactable");
        defaultMask = LayerMask.GetMask("Default");

        targetPos = transform.position;

        Vector2 sizeRef = new Vector2(size.x, size.y);
        Vector2 gridSize = new Vector2(3, 3);
        upperBound = gridSize - (sizeRef / 2);
        lowerBound = -gridSize + (sizeRef / 2);

        col = GetComponent<BoxCollider>();
    }

    public void SetSelect(bool select, Transform hand)
    {
        selected = select;
        this.hand = hand;

        if (hand != null)
        {
            if (Physics.Raycast(hand.position, hand.forward, out RaycastHit hit, Mathf.Infinity, interactableMask))
            {
                contactPos = main.InverseTransformPoint(hit.point) - main.InverseTransformPoint(transform.position);
            }
        }
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * 7);
        if (manager.GetWin()) { return; }

        col.center = transform.InverseTransformPoint(main.TransformPoint(localTarget));

        if (selected)
        {
            bool ray = Physics.Raycast(hand.position, hand.forward, out RaycastHit hit, Mathf.Infinity, defaultMask);

            if (!ray) { return; }

            if (horizontal)
            {
                CheckHorizontal(main.InverseTransformPoint(hit.point).x - main.InverseTransformPoint(targetPos + contactPos).x);
            }
            if (vertical)
            {
                CheckVertical(main.InverseTransformPoint(hit.point).y - main.InverseTransformPoint(targetPos + contactPos).y);
            }
        }
    }

    void CheckVertical(float y)
    {
        Vector3 offset = new Vector3(0, ((float)size.y / 2) + 0.5f, 1);

        if (y < -0.5f)
        {
            CheckMove(main.TransformPoint(main.InverseTransformPoint(targetPos) - offset), Vector3.down);
        }
        else if (y > 0.5f)
        {
            offset.z = -1;
            CheckMove(main.TransformPoint(main.InverseTransformPoint(targetPos) + offset), Vector3.up);
        }
    }

    void CheckHorizontal(float x)
    {
        Vector3 offset = new Vector3(((float)size.x / 2) + 0.5f, 0, 1);

        if (x < -0.5f)
        {
            CheckMove(main.TransformPoint(main.InverseTransformPoint(targetPos) - offset), Vector3.left);
        }
        else if (x > 0.5f)
        {
            offset.z = -1;
            CheckMove(main.TransformPoint(main.InverseTransformPoint(targetPos) + offset), Vector3.right);
        }
    }

    void CheckMove(Vector3 point, Vector3 offset)
    {
        if (!Physics.Raycast(point, main.forward, 2, interactableMask))
        {
            Vector3 localTargetPos = main.InverseTransformPoint(targetPos);
            localTargetPos += offset;
            localTargetPos.x = Mathf.Clamp(localTargetPos.x, lowerBound.x, upperBound.x);
            localTargetPos.y = Mathf.Clamp(localTargetPos.y, lowerBound.y, upperBound.y);
            targetPos = main.TransformPoint(localTargetPos);
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PuzzlePieceInteractable))]
public class PuzzlePiece : MonoBehaviour
{
    public Vector2Int size;
    public bool horizontal, vertical;

    Vector3 localTargetPos;

    public Transform main;
    public GameObject grid;

    bool selected = false;
    Transform hand;
    Vector3 contactPos;

    int interactableMask, defaultMask;
    Vector2 upperBound, lowerBound;

    BoxCollider col;
    public PuzzleManager manager;

    private void Awake()
    {
        interactableMask = LayerMask.GetMask("Interactable");
        defaultMask = LayerMask.GetMask("Default");

        localTargetPos = transform.localPosition;

        Vector2 sizeRef = new Vector2(size.x, size.y);
        Vector2 gridSize = new Vector2(3, 3);
        upperBound = gridSize - (sizeRef / 2);
        lowerBound = -gridSize + (sizeRef / 2);

        col = GetComponent<BoxCollider>();
    }

    public void SetSelect(bool select, Transform hand)
    {
        selected = select;
        this.hand = hand;

        if (hand != null)
        {
            if (Physics.Raycast(hand.position, hand.forward, out RaycastHit hit, Mathf.Infinity, interactableMask))
            {
                contactPos = main.InverseTransformPoint(hit.point) - main.InverseTransformPoint(transform.position);
            }
        }
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, localTargetPos, Time.deltaTime * 7);
        if (manager.GetWin()) { return; }

        col.center = transform.InverseTransformPoint(main.TransformPoint(localTargetPos));

        if (selected)
        {
            bool ray = Physics.Raycast(hand.position, hand.forward, out RaycastHit hit, Mathf.Infinity, defaultMask);

            if (!ray) { return; }

            if (horizontal)
            {
                CheckHorizontal(main.InverseTransformPoint(hit.point).x - (localTargetPos + contactPos).x);
            }
            if (vertical)
            {
                CheckVertical(main.InverseTransformPoint(hit.point).y - (localTargetPos + contactPos).y);
            }
        }
    }

    void CheckVertical(float y)
    {
        Vector3 offset = new Vector3(0, ((float)size.y / 2) + 0.5f, 1);

        if (y < -0.5f)
        {
            CheckMove(main.TransformPoint(localTargetPos - offset), Vector3.down);
        }
        else if (y > 0.5f)
        {
            offset.z = -1;
            CheckMove(main.TransformPoint(localTargetPos + offset), Vector3.up);
        }
    }

    void CheckHorizontal(float x)
    {
        Vector3 offset = new Vector3(((float)size.x / 2) + 0.5f, 0, 1);

        if (x < -0.5f)
        {
            CheckMove(main.TransformPoint(localTargetPos - offset), Vector3.left);
        }
        else if (x > 0.5f)
        {
            offset.z = -1;
            CheckMove(main.TransformPoint(localTargetPos + offset), Vector3.right);
        }
    }

    void CheckMove(Vector3 point, Vector3 offset)
    {
        if (!Physics.Raycast(point, main.forward, 2, interactableMask))
        {
            localTargetPos += offset;
            localTargetPos.x = Mathf.Clamp(localTargetPos.x, lowerBound.x, upperBound.x);
            localTargetPos.y = Mathf.Clamp(localTargetPos.y, lowerBound.y, upperBound.y);
        }
    }
}
