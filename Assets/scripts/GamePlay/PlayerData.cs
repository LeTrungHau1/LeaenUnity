using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[Serializable]
public class PlayerData
{
    public string Name;
    public int Level;
    public int Gold;
}

[Serializable]
public class ListPlayer
{
    public PlayerData[] PlayerData;
}