using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour
{
    //Attributes:
    [Header("Testing purposes only!")]
    public GameObject template_listener; //For testing purposes, only!
    [Header("Main Settings")]
    public int length = 0;
    public Vector3 spacing = new Vector2(1, 0);
    public List<Listener> elements;
    private const string listener_tag = "Letter";

    //Methods:
    private void Start()
    {
        //Initialise list of elements & initialise listeners.
        elements = new List<Listener>();
        for(int i =0; i < length; i++)
        {
            Listener letter_listener = GameObject.Instantiate(template_listener).AddComponent<Listener>();
            letter_listener.gameObject.transform.position += transform.position + spacing * i;
            letter_listener.gameObject.name = "ListenerObject_"+i;
            letter_listener.payload_tag = listener_tag;
            letter_listener.gameObject.transform.SetParent(FindObjectOfType<Canvas>().transform);
            elements.Add(letter_listener);
        }
    }

    public string GetString()
    {
        string word = "";

        for(int i =0; i < elements.Count; i++)
        {
            if (elements[i].IsEmpty()) continue;
            word +=  elements[i].GetPayload<Letter>().character.ToString();
        }

        return word;
    }

    public char[] GetArray()
    {
        List<char> characters = new List<char>(); //Start with a list since we do not know how many listeners have a valid object reference yet.

        for(int i =0; i < elements.Count; i++)
        {
            if (elements[i].IsEmpty()) continue;
            characters.Add(elements[i].GetPayload<Letter>().character);
        }

        return characters.ToArray();
    }

    public void DebugWord()
    {
        Debug.Log("Word: " + GetString());
    }
}
