using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textDisplay;

    [SerializeField]
    private Image portrait;

    [SerializeField]
    private float wordsPerMinute = 70.0f;

    [SerializeField]
    private AudioSource click;

    private Coroutine typing;
    private float characterDelay;

    public delegate void TextProcessor(ref string text);
    public event TextProcessor PreProcessText;

    public void StartDialogue(Dialogue dialogue)
    {
        if (typing != null)
        {
            EndDialogue();
            return;
        }

        dialogue.FillDialoguePortrait(portrait);
        gameObject.SetActive(true);
        dialogue.WriteDialogue(this);
    }

    public void EndDialogue()
    {
        if (typing != null)
        {
            StopCoroutine(typing);
            typing = null;
            DisplayAllText(textDisplay);
        }
    }

    public void TypeDialogue(string line)
    {
        typing = StartCoroutine(TypingRoutine(line));
    }

    private static void DisplayAllText(TMP_Text text)
    {
        text.maxVisibleCharacters = text.textInfo.characterCount;
    }

    private static bool Finished(TMP_Text text)
    {
        return text.maxVisibleCharacters == text.textInfo.characterCount;
    }

    private IEnumerator TypingRoutine(string line)
    {
        PreProcessText?.Invoke(ref line);
        textDisplay.text = line;
        textDisplay.maxVisibleCharacters = 0;
        do
        {
            textDisplay.maxVisibleCharacters++;
            if (click)
            {
                click.Play();
            }
            const float lettersPerWord = 4.79f;
            const float charactersPerWord = lettersPerWord + 1;
            float charactersPerMinute = wordsPerMinute * charactersPerWord;
            characterDelay = 60.0f / charactersPerMinute;
            yield return new WaitForSeconds(characterDelay);
        }
        while (!Finished(textDisplay));
        typing = null;
    }
}
