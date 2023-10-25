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

    private readonly string path = "Assets/DataBase/Players.txt";


    public void Save()
    {
        //separa por vírgula só se o arquivo existir
        if(File.Exists(path)) {
            var file = File.AppendText(path);
            file.WriteLine(";"); // Adiciona o texto ao fim do arquivo
            file.Close();
        }
        
        var content = JsonUtility.ToJson(this, true);
        File.AppendAllText(path, content);

    }

    public string[] LoadData()
    {
        var players = File.ReadAllText(path); 
        
        string[] playerList = players.Split(';');

        return playerList;
    }
}
