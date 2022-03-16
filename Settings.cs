using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace FF_UI
{
    public struct GameSettings
    {
        //Attributes:
        public bool vibration, mute, censored;
        public float volume;
        private const string file_name = "saved_settings.JSON";

        //Constructor:
        public GameSettings(float volume)
        {
            vibration = false; mute = false; censored = false;
            this.volume = volume;
        }

        //Properties:
        public string GetFilePath() { return Application.persistentDataPath +"/"+ file_name; }

        //Methods:
        public void Serialise()
        {
            string data = JsonUtility.ToJson(this);
            File.WriteAllText(GetFilePath(), data);
            Debug.Log("Saved settings at path: " + GetFilePath());
        }

        public bool Load()
        {
            //If no data has been saved at file path exit method and return false.
            if(!File.Exists(GetFilePath())) return false;

            //Otherwise, load data into this instance of 'GameSettings' and return true.
            string jsonObject = File.ReadAllText(GetFilePath());
            this = JsonUtility.FromJson<GameSettings>(jsonObject);
            return true;
        }

        //Static methods:
        public static GameSettings GetDefault()
        {
            GameSettings settings = new GameSettings(100.0f);
            settings.mute = false;
            settings.vibration = true;
            settings.censored = false;
            return settings;
        }
    }
}
