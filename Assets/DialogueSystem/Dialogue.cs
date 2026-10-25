using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue System/Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField]
    private Character character;

    [SerializeField][Multiline]
    private string line;

    public IEnumerator TypeDialogueContent(TMP_Text textDisplay, float charactersPerSecond)
    {
        float characterDelay = 1f / charactersPerSecond;
        StringBuilder typing = new();
        foreach (char letter in line.ToCharArray())
        {
            typing.Append(letter);
            textDisplay.text = typing.ToString();
            yield return new WaitForSeconds(characterDelay);
        }
    }

    public void FillDialoguePortrait(Image portrait)
    {
        character.FillPortrait(portrait);
    }
}
