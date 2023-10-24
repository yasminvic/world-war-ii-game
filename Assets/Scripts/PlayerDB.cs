using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

[Serializable]
public class PlayerDB 
{
    public string username;

    public string password;

    public int score;

    public int weapon;

    private string path = "Assets/DataBase/Player.txt";


    public void Save()
    {
        var content = JsonUtility.ToJson(this, true);
        File.WriteAllText(path, content);
    }
}
