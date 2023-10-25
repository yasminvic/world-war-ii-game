using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Players 
{
    public List<PlayerDB> players = new List<PlayerDB>();

    private string path = "Assets/DataBase/PlayerList.json";

    public void Save()
    {
        var content = JsonUtility.ToJson(this, true);
        File.AppendAllText(path,content);

        var file = File.AppendText(path);
        file.WriteLine(","); // Adiciona o texto ao fim do arquivo
        file.Close();
    }

    public void LoadData(string json)
    {
        var playerList = JsonUtility.FromJson<Players>(json);
        players = playerList.players;

        Debug.Log(players);
    }
}
