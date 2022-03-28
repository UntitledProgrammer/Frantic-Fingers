using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace FranticFingers.Mechanics
{
    public enum Difficulty
    {
        Easy = 4,
        Medium = 5,
        Hard = 6
    }

    [RequireComponent(typeof(Word))]
    public class AnagramGenerator : MonoBehaviour
    {
        //Attributes:
        [Header("Main Settings")]
        public Difficulty difficulty = Difficulty.Easy;

        public Letter[] letters = null;
        private Word word;

        //Methods:
        public void GenerateLetters(string tag = "Untagged")
        {
            //Initalise & assign each letter:
            letters = new Letter[(int)difficulty];
            for(int i = 0; i < letters.Length; i++) { letters[i] = Letter.Create(); letters[i].transform.position = transform.position + Vector3.left * Letter.default_size * i; letters[i].tag = tag; }
        }

        //Base Methods:
        private void Start()
        {

        }

        private void OnDrawGizmosSelected()
        {

        }
    }

    [CustomEditor(typeof(AnagramGenerator))]
    class AnagramGeneratorEditor : Editor
    {
        //Attributes:
        private AnagramGenerator self;
        private const int seperation = 25;
        private string tag;

        //Base methods:
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Developer Settings");
            tag = EditorGUILayout.TagField(tag);
            if (GUILayout.Button("Auto Assign Letters")) self.GenerateLetters(tag);
            else if (GUILayout.Button("Clear Letters")) { }

            EditorGUILayout.Space(seperation);
            EditorGUILayout.LabelField("Main Settings:");
            if(self.letters == null || self.letters.Length != (int)self.difficulty)
            {
                self.letters = new Letter[(int)self.difficulty];
            }

            DrawDefaultInspector();
        }

        private void OnEnable()
        {
            self = (AnagramGenerator)target;
        }
    }
}