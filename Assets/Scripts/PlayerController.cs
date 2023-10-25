using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerDB player;


    void Start()
    {
        player = new PlayerDB();

        player.username = "yasminvic";
        player.password = "password";
        player.score = 1;
        player.weapon = 0;

        player.Save();

        var playerList = player.LoadData();

        foreach (var player in playerList)
        {
            var playerToString = JsonUtility.FromJson<PlayerDB>(player);

            PlayerDB playerConverted = new PlayerDB();
            playerConverted.username = playerToString.username;
            playerConverted.password = playerToString.password;
            playerConverted.score = playerToString.score;
            playerConverted.weapon = playerToString.weapon;

            Debug.Log(playerConverted.username);

        }

    }

}
