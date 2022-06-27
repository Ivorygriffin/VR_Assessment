using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchSelectInput : MonoBehaviour
{
    public SelectInput left, right;
    int layerMask;

    private void Awake()
    {
        layerMask = LayerMask.GetMask("Interactable");
    }

    private void Update()
    {
        CheckHand(left);
        CheckHand(right);
    }

    void CheckHand(SelectInput input)
    {
        bool baseValues = true;

        if (Physics.Raycast(input.controller.transform.position, input.controller.transform.forward, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.gameObject.CompareTag("Clickable"))
            {
                baseValues = false;
            }
        }

        if (baseValues != input.Base())
        {
            input.SetBase(baseValues);
        }
    }
}

[System.Serializable]
public class SelectInput
{
    public ActionBasedController controller;
    public InputActionProperty baseSelect, baseSelectValue, newSelect, newSelectValue;
    bool baseValue = false;

    public bool Base()
    {
        return baseValue;
    }

    public void SetBase(bool v)
    {
        baseValue = v;

        controller.selectAction = baseValue ? baseSelect : newSelect;
        controller.selectActionValue = baseValue ? baseSelectValue : newSelectValue;
    }
}
