using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Listener: MonoBehaviour
{
    //Attributes:
    public string payload_tag;
    public GameObject payload_ref; 

    //Methods:
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == payload_tag)
        {
            payload_ref = collision.gameObject;
            collision.gameObject.transform.position = transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        payload_ref = null;
    }

    public bool IsEmpty()
    {
        return payload_ref == null ? true : false;
    }

    public PayloadType GetPayload<PayloadType>()
    {
        return payload_ref.GetComponent<PayloadType>();
    }

}
