using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogue;

    [SerializeField]
    private DialogueBox dialogueBox;

    public void OnEnable()
    {
        dialogueBox.BeforeDisplay += ColorText;
        dialogueBox.BeforeDisplay += AllCaps;
    }

    public void OnDisable()
    {
        dialogueBox.BeforeDisplay -= AllCaps;
        dialogueBox.BeforeDisplay -= ColorText;
    }

    private void ColorText(ref string text)
    {
        string replacements = "Mario|princess";
        text = Regex.Replace(text, replacements, (word) => $"<color=red>{word}</color>");
    }

    private void AllCaps(ref string text)
    {
        text = text.ToUpper();
    }

    public void Interact()
    {
        dialogueBox.gameObject.SetActive(true);
        dialogueBox.StartDialogue(dialogue);
    }

    public void Exit()
    {
        dialogueBox.EndDialogue();
        dialogueBox.gameObject.SetActive(false);
    }
}
