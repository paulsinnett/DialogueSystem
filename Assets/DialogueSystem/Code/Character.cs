using System.Collections.Generic;
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

    public void Add(Dictionary<string, Character> cast)
    {
        cast[displayName] = this;
    }
}
