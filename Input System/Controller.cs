using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
namespace FF_Input
{
    public class Payload : UnityEngine.UI.Button
    {
        //Attributes:
        private char character;
        private Text textbox;

        //Methods:
        void SetChar(char c)
        {
            character = c;
            textbox.text = c.ToString();
        }
    }


    public class Controller : MonoBehaviour
    {
        //Attributes:
        private GameObject selected = null;
        private RaycastHit2D hit;

        private void Update()
        {
            hit = Physics2D.Raycast(Input.mousePosition, Vector3.forward, Mathf.Infinity);
            Debug.DrawRay(Input.mousePosition, Vector3.forward * 10.0f, Color.red);

            if(hit.collider.gameObject)
            {
                selected = gameObject;
            }

            selected.transform.position = Input.mousePosition;
        }
    }
}
