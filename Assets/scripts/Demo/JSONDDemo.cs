using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class JSONDDemo : MonoBehaviour
{
    public TextMeshProUGUI PlayerName;
    public TextMeshProUGUI PlayerLevel;
    public TextMeshProUGUI PlayerGold;
    public ListPlayer listPlayer;
    private string json;
    private string dataPath;
    private void Awake()
    {
        dataPath = Application.persistentDataPath + "/PlayerData.json";
        Debug.Log(dataPath);
    }
    void Start()
    {
        //PlayerData playerData = new PlayerData
        //{
        //    Name = "hau",
        //    Level = 1,
        //    Gold = 100

        //};
        json=JsonUtility.ToJson(listPlayer);
        Debug.Log(json);
    }
    public void LoadPlayerData()
    {
        string loadjson =File.ReadAllText(dataPath);
        if(loadjson !=null )
        {
            //PlayerData loadPlayerData =JsonUtility.FromJson<PlayerData>(loadjson);
            //PlayerName.text ="player Name :" + loadPlayerData.Name;
            //PlayerLevel.text="player level :" + loadPlayerData.Level;
            //PlayerGold.text="player Gold :" + loadPlayerData.Gold;


            ListPlayer loadPlayerData = JsonUtility.FromJson<ListPlayer>(loadjson);
            PlayerName.text = "player Name :" + loadPlayerData.PlayerData[2].Name;
            PlayerLevel.text = "player level :" + loadPlayerData.PlayerData[2].Level;
            PlayerGold.text = "player Gold :" + loadPlayerData.PlayerData[2].Gold;
        }
    }
    public void SavePlayerData()
    {
        File.WriteAllText(dataPath, json);
    }
    public void UpdatePlayerData()
    {
        //PlayerData newData = new PlayerData
        //{
        //    Name = "hau02",
        //    Level = 2,
        //    Gold = 200
        //};
        //PlayerName.text = "player Name :" + newData.Name;
        //PlayerLevel.text = "player level :" + newData.Level;
        //PlayerGold.text = "player Gold :" + newData.Gold;


        string loadjson = File.ReadAllText(dataPath);
        ListPlayer newData = JsonUtility.FromJson<ListPlayer>(loadjson);
        PlayerName.text = "player Name :" + newData.PlayerData[1].Name;
        PlayerLevel.text = "player level :" + newData.PlayerData[1].Level;
        PlayerGold.text = "player Gold :" + newData.PlayerData[1].Gold;

        //json = JsonUtility.ToJson(newData);
        SavePlayerData();
    }
}
