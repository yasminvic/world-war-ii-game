using System;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public string title;
    [TextArea(3,10)]
    public string[] sentences;
}
