using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FF_UI
{
    public class SettingsMenu : MonoBehaviour
    {
        //Attributes:
        public Button toggle_button;
        private GameSettings settings;

        //Methods:
        void Start()
        {
            //Error handling.
            if (toggle_button == null)
            {
                Debug.LogError("Error, failed to use toggle button. Select a button in the inspector window.");
                Destroy(this);
            }

            toggle_button.onClick.AddListener(delegate () { ToggleState(); });
            settings = GameSettings.GetDefault();
        }

        void Update()
        {

        }

        //Static methods:
        public void ToggleState()
        {
            settings.Load();
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }

}