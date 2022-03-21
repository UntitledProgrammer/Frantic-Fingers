using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    //Attributes:
    public char character = '0';
    private RaycastHit2D hit;
    private const int left_mouse_button = 0; 

    //Methods:
    private void Update()
    {
        hit = Physics2D.Raycast(Input.mousePosition, Vector3.forward, Mathf.Infinity);
        if(hit.collider != null && hit.collider.gameObject == gameObject && Input.GetMouseButton(left_mouse_button))
        {
            transform.position = Input.mousePosition;
        }
    }
}
