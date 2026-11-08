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

    [SerializeField]
    [Multiline]
    private string line;

    public void WriteDialogue(DialogueBox box)
    {
        box.TypeDialogue(line);
    }

    public void FillDialoguePortrait(Image portrait)
    {
        speaker.FillPortrait(portrait);
    }
}
