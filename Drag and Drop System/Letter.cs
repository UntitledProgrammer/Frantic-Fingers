using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

///<summary>The letter class is a light weight component.</summary>
public class Letter : MonoBehaviour
{
    //Attributes:
    public char character = default_character;
    [HideInInspector]
    public int size = default_size;

    private RaycastHit2D hit;
    private const TextAnchor anchor = TextAnchor.MiddleCenter;
    private const char default_character = '-';
    private const int default_size = 50;

    //Components:
    public Text text_box;
    private BoxCollider2D box_collider;
    private Rigidbody2D body2D;

    //Methods:
    public void BuildLetter()
    {
        //Create and setup text-box.
        text_box = gameObject.AddComponent<Text>();
        text_box.fontSize = size;
        text_box.alignment = anchor;
        text_box.text = character.ToString();

        //Create and setup box-collider.
        box_collider = gameObject.AddComponent<BoxCollider2D>();
        SetColliderSize(size);

        //Create and setup rigid-body.
        body2D = gameObject.AddComponent<Rigidbody2D>();
        body2D.freezeRotation = true;
    }

    public void DestroyLetter()
    {
        Destroy(box_collider);
        Destroy(text_box);
    }
    [MenuItem("GameObject/UI/Create Letter", priority = 0)]
    static public void CreateLetter()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        Letter letter = new GameObject("Letter").AddComponent<Letter>();
        letter.gameObject.transform.SetParent(canvas.transform);
        letter.gameObject.transform.position = canvas.transform.position;
        letter.BuildLetter();
    }

    public void SetColliderSize(int scale)
    {
        //It's important that the box collider is always a 'true sqaure' to fit the visual letter.
        box_collider.size = new Vector2(scale, scale);
    }

    private void Awake()
    {
        //Setup Object:
    }
}

[CustomEditor(typeof(Letter))]
public class LetterEditor : Editor
{
    //Attributes:
    private Letter self;
    private const int seperation = 20;
    private const int sensitivity = 10;

    //Methods:
    public void OnEnable()
    {
        //Assign self.
        self = (Letter)target;
    }

    public override void OnInspectorGUI()
    {
        //Present developer settings:
        GUILayout.Label("Developer Settings:");
        if(GUILayout.Button("Build Letter"))
        {
            self.BuildLetter();
        }
        else if(GUILayout.Button("Destroy Letter"))
        {
            self.DestroyLetter();
        }

        //Present main settings:
        GUILayout.Space(seperation);
        GUILayout.Label("Main Settings");

        if(self.text_box != null)
        {
            self.text_box.fontSize = EditorGUILayout.IntSlider(self.text_box.fontSize, 0, self.text_box.fontSize + sensitivity);
        }

        base.OnInspectorGUI();
    }
}
