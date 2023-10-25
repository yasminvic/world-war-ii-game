using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private PlayerDB player;

    [SerializeField]
    public TMP_InputField username;
    [SerializeField]
    public TMP_InputField password;
    [SerializeField]
    public GameObject alert;

    void Start()
    {
        player = new PlayerDB();
    }

    public void SavePlayer()
    {
        //PlayerDB player = new PlayerDB();
        player.username = username.text;
        player.password = password.text;
        player.score = 0;
        player.weapon = 0;

        if (ValidacaoPlayer())
        {
            player.Save();
            alert.SetActive(false);
        } 

    }

    public bool ValidacaoPlayer()
    {
        var playerList = player.LoadData();

        foreach (var player in playerList)
        {
            var playerToString = JsonUtility.FromJson<PlayerDB>(player);

            if (playerToString.username.Equals(username.text))
            {
                alert.SetActive(true);
                return false;
            }
        }

        return true;
    }

    /*
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


        }
        

    }
    */

}
