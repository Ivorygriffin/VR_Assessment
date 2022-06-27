using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzlePieceInteractable : XRSimpleInteractable
{
    PuzzlePiece piece;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        PuzzlePiece piece = args.interactableObject.transform.GetComponent<PuzzlePiece>();
        piece.SetSelect(true, args.interactorObject.transform);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if (piece != null)
        {
            piece.SetSelect(false, null);
        }
    }
}
