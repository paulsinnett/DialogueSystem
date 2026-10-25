using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character", menuName = "Dialogue System/Character")]
public class Character : ScriptableObject
{
    [SerializeField]
    private string displayName;

    [SerializeField]
    private Sprite image;

    public void FillPortrait(Image portrait)
    {
        portrait.sprite = image;
    }

    public string ReplaceName(string text)
    {
        string colorText = $"<color=red>{displayName}</color>";
        return text.Replace(displayName, colorText);
    }
}
