using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    [SerializeField]
    private Image imagem;

    [SerializeField]
    private string[] imagens;
    // Start is called before the first frame update
    void Start()
    {
        imagem.sprite = Resources.Load<Sprite>($"CutScenes/{imagens[0]}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
