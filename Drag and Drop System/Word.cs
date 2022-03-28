using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

    }

    public void CreateListeners(int length, string tag = listener_tag)
    {
        //Initialise list of elements & initialise listeners.
        elements = new List<Listener>();
        elements.Clear();

        //Add listeners.
        for (int i = 0; i < length; i++)
        {
            Listener letter_listener = GameObject.Instantiate(template_listener).AddComponent<Listener>();
            letter_listener.gameObject.transform.position += transform.position + spacing * i;
            letter_listener.gameObject.name = "ListenerObject_" + i;
            letter_listener.payload_tag = tag;
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

[CustomEditor(typeof(Word))]
public class WordEditor : Editor
{
    //Attributes:
    private const int min = 0, max = 10;
    private int number_of_listeners = 0;
    private Word self;
    private string editor_tag = "";

    //Methods:
    public void OnEnable()
    {
        //Set reference to instance of the object this class is editing.
        self = (Word)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Developer Settings");
        number_of_listeners = EditorGUILayout.IntSlider(number_of_listeners, min, max);
        editor_tag = EditorGUILayout.TagField(editor_tag);
        if(GUILayout.Button("Create Listeners"))
        {
            self.CreateListeners(number_of_listeners, editor_tag);
        }

        if(GUILayout.Button("Destroy Listeners"))
        {
            //Implement.
        }

        EditorGUILayout.LabelField("Main Settings");
        DrawDefaultInspector();
    }
}