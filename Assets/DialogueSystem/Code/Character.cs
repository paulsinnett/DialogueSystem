using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character", menuName = "Dialogue System/Character")]
public class Character : ScriptableObject
{
    [SerializeField]
    private string displayName;

    [SerializeField]
    private Sprite image;

    [SerializeField]
    private string color = "red";

    public void FillPortrait(Image portrait)
    {
        portrait.sprite = image;
    }

    public void Add(Dictionary<string, Character> cast)
    {
        cast[displayName] = this;
    }

    public string ColorText(string text)
    {
        return $"<color={color}>{text}</color>";
    }
}
