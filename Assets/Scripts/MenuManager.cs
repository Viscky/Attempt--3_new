using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using System.IO;
using UnityEngine.UI;

//This is a new version Menu Manager

public class MenuManager : MonoBehaviour
{

    public TextMeshProUGUI Record;
    public TMP_InputField playersName;
    public string enteredName;

   
    public string lastPlayer;
    public string recordName;


    public int lastPlayerResult;
    public int record;

    // Start is called before the first frame update
    void Start()
    {
        LoadRecord();
    }

    // Update is called once per frame
    void Update()
    {
        enteredName = playersName.text;
         
    }

    //Start of the game, when button is clicked 
    public void StartNew()
    {
        SaveRecord();
        SceneManager.LoadScene("main");
    }

    //Finish of the game, when button is clicked 
    public void Exit()
    {
        EditorApplication.ExitPlaymode();
    }

    //Savind and loading results
    [System.Serializable]
    class SaveData
    {
        public string enteredName;
        public string lastPlayer;
        public string recordName;


        public int lastPlayerResult;
        public int record;

    }

    public void SaveRecord()
    {
        SaveData data = new SaveData();
        data.enteredName = enteredName;
        data.lastPlayer = lastPlayer;
        data.record = record;
        data.lastPlayerResult = lastPlayerResult;
        data.recordName = recordName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            enteredName = data.enteredName;
            lastPlayer = data.lastPlayer;
            record = data.record;
            lastPlayerResult = data.lastPlayerResult;
            recordName = data.recordName;
        }
    }
}
