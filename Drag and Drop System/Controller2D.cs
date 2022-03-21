using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The 'controller-2D' class is designed for moving on screen, UI elements.
/// The UI elements intended for interaction must have an active 2D 'collider'.
/// </summary>
public class Controller2D : MonoBehaviour
{
    //Attributes:
    public string payload_tag = "";
    private const int left_mouse_button = 0;
    private RaycastHit2D hit;

    //Methods:
    private void Update()
    {
        //If left mouse button is not down, do not consider moving an payload.
        if (!Input.GetMouseButton(left_mouse_button)) return;

        //Otherwise, cast a ray to determine whether an object is under the current mouse position.
        hit = Physics2D.Raycast(Input.mousePosition, Vector3.forward, Mathf.Infinity); //Note, this system makes the presumption that we are using 'screen space' (not world space).
        if(hit.collider != null && hit.collider.tag == payload_tag)
        {
            hit.collider.gameObject.transform.position = Input.mousePosition;
        }
    }
}
