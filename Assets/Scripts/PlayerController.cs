using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerDB player;
    public Players players;


    void Start()
    {
        player = new PlayerDB();
        players = new Players();


        player.username = "yasminvic";
        player.password = "password";
        player.score = 1;
        player.weapon = 0;

        player.Save();
        players.LoadData(player.LoadData());



        //players.players.Add(player);
        //players.Save();

    }

}
