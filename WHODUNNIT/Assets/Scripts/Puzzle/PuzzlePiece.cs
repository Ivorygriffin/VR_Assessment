using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PuzzlePieceInteractable))]
public class PuzzlePiece : MonoBehaviour
{
    public Vector2Int size;
    public bool horizontal, vertical;
    bool selected = false;
    Transform hand;
    Vector3 contactPos;

    int interactableMask, defaultMask;

    private void Awake()
    {
        interactableMask = LayerMask.GetMask("Interactable");
        defaultMask = LayerMask.GetMask("Default");
    }

    public void SetSelect(bool select, Transform hand)
    {
        selected = select;
        this.hand = hand;

        if (hand != null)
        {
            if (Physics.Raycast(hand.position, hand.forward, out RaycastHit hit, Mathf.Infinity, interactableMask))
            {
                contactPos = hit.point - transform.position;
                Debug.Log(contactPos);
            }
        }
    }

    private void Update()
    {
        if (selected)
        {

        }
    }
}
