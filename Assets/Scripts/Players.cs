using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Players 
{
    public List<PlayerDB> players = new List<PlayerDB>();

    private string path = "Assets/DataBase/Players.txt";

    public void Save()
    {
        var content = JsonUtility.ToJson(this, true);
        File.WriteAllText(path,content);
    }
}
