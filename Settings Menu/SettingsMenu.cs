using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FF_UI
{
    public class SettingsMenu : MonoBehaviour
    {
        //Attributes:
        [Header("Settings")]
        public GameSettings settings;
        public Scrollbar volume;

        //Methods:
        void Start()
        {
            settings = GameSettings.GetDefault();
            volume.onValueChanged.AddListener(delegate { SetFloat(ref settings.volume, volume.value); });
        }

        //UI methods:
        public void ToggleState()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void ToggleVibration()
        {
            settings.vibration = !settings.vibration;
        }

        public void ToggleCensorship()
        {
            settings.censored = !settings.censored;
        }

        public void SetFloat(ref float reference, float value)
        {
            reference = value;
        }
    }

}