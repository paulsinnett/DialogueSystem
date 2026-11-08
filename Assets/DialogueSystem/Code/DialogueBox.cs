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

    public delegate void PreProcessText(ref string text);
    public event PreProcessText BeforeDisplay;

    public void Awake()
    {
        const float averageWordLength = 5.7f;
        float charactersPerMinute = wordsPerMinute * averageWordLength;
        characterDelay = 60.0f / charactersPerMinute;
    }

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
            textDisplay.maxVisibleCharacters = textDisplay.textInfo.characterCount;
        }
    }

    public void TypeDialogue(string line)
    {
        typing = StartCoroutine(TypingRoutine(line));
    }

    private IEnumerator TypingRoutine(string line)
    {
        BeforeDisplay?.Invoke(ref line);
        textDisplay.text = line;
        int i = 0;
        do
        {
            textDisplay.maxVisibleCharacters = i;
            if (click)
            {
                click.Play();
            }
            yield return new WaitForSeconds(characterDelay);
            i++;
        }
        while (i < textDisplay.textInfo.characterCount);
    }
}
