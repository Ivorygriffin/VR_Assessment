using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    public UnityEvent OnClicked;
    public Vector2 clickPosition;
    public bool clicked;

    public void Update()
    {
        if (clicked)
        {
            Ray ray = Camera.main.ScreenPointToRay(clickPosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {

                Debug.Log("left click");
                if (hit.transform.tag == "Interactable")
                {
                    Debug.Log(hit.point);
                    OnClicked.Invoke();
                }
                
            }
            clicked = false;
        }
    }
    
    void Onclick()
    {
        clicked = !clicked;
    }
    void OnMouseposition(InputValue value)
    {
        clickPosition = value.Get<Vector2>();
    }



}
