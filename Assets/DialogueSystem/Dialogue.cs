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
    private Character speaker;

    [SerializeField][Multiline]
    private string line;

    public IEnumerator TypeDialogueContent(TMP_Text textDisplay, float charactersPerSecond, Character[] characters)
    {
        
        string displayLine = line;
        foreach (Character character in characters)
        {
            displayLine = character.ReplaceName(displayLine);
        }
        textDisplay.text = displayLine;
        int totalCharacters = textDisplay.maxVisibleCharacters;
        float characterDelay = 1f / charactersPerSecond;
        for (int i = 0; i < totalCharacters; i++)
        {
            textDisplay.maxVisibleCharacters = i;
            yield return new WaitForSeconds(characterDelay);
        }
    }

    public void FillDialoguePortrait(Image portrait)
    {
        speaker.FillPortrait(portrait);
    }
}
