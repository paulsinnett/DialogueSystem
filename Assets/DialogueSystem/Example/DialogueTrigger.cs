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
        dialogueBox.PreProcessText += ColorText;
    }

    public void OnDisable()
    {
        dialogueBox.PreProcessText -= ColorText;
    }

    private static void ColorText(ref string text)
    {
        string replacements = "Mario|princess";
        text = Regex.Replace(text, replacements, ColorWord);
        return;

        static string ColorWord(Match word)
        {
            return $"<color=red>{word.Value}</color>";
        }
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
