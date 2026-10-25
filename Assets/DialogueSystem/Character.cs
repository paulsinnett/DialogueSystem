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

    internal void FillPortrait(Image portrait)
    {
        portrait.sprite = image;
    }
}
