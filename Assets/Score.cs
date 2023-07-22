using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Header("Score Text")]
    [SerializeField]
    private TextMeshProUGUI text;
    void Start()
    {
        text.text = "0";
    }

    public void UpdateScore(int score)
    {
        text.text = score.ToString();
    }
}
