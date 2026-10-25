using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public static DialogueBox Instance;

    [SerializeField]
    private TMP_Text textDisplay;

    [SerializeField]
    private Image portrait;

    [SerializeField]
    private float charactersPerSecond = 20.0f;

    private Coroutine typing;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Multiple instances of DialogueBox detected. There should only be one instance in the scene.");
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogue.FillDialoguePortrait(portrait);
        gameObject.SetActive(true);
        typing = StartCoroutine(dialogue.TypeDialogueContent(textDisplay, charactersPerSecond));
    }

    public void EndDialogue()
    {
        StopCoroutine(typing);
        gameObject.SetActive(false);
    }
}
