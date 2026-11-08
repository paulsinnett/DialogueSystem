# Dialogue System

This component displays dialogue text one letter at a time. Or you can skip to the end.

## Example

You can find the example scene in the `DialogueSystem/Example` folder. It is named `DialogueSystem`. This scene presents two boxes. The red one represents the player and the white one represents an NPC. Use `WASD` to move the player close to the NPC, then press `E` to interact.

The dialogue window should appear at that point, showing a portrait of the speaking character, and the text will appear one letter at a time with a click sound.

You can jump to the end of the text by pressing the `E` key again.

Leaving the vicinity of the NPC closes the dialogue window.

![Example Scene](./screenshot.png)

## Usage

This component provides two scriptable objects: `Character` and `Dialogue`. You can create these from the `Assets` menu:
```
Assets -> Create -> DialogueSystem -> Character
Assets -> Create -> DialogueSystem -> Dialogue
```

These are then used by the `DialogueBox` behaviour script which you should apply to your dialogue box object.

### Character

The character scriptable objects store data relating to a character with dialogue. For each character you must provide their display name and a portrait sprite.

### Dialogue

The dialogue scriptable objects store individual dialogue lines for a character. For each line of dialogue you must provide the `Character` scriptable object representing the speaker, and the dialogue line.

The dialogue line is a multi-line string so you can include line breaks in a line of dialogue.

### DialogueBox

This script should be placed on the object you want to use to display your dialogue text. The dialogue text is written into a `TMP_Text` object and a reference to that object must be attached to the instance of the `DialogueBox` behaviour. The character portrait is displayed in an `Image` component and a reference to that object must also be attached to the instance of the `DialogueBox` behaviour.

You can adjust the speed of the text playback in the `Words Per Minute` slot. The speed is calculated using [the average word length of 4.79 letters per word in English](https://www.norvig.com/mayzner.html), plus 1 for a space. The default is set to 150, which is the sustained typing speed of the [current world record holder](https://fasttypings.com/typing-speed-world-record).

You can provide an optional `AudioSource` to play a sound after each character is displayed.

You can also provide a text processing function to make changes to the text before rendering. You can use this to make text replacements. In the example code this is used to color the words `Mario` and `princess`.

---

To activate the dialogue display process in response to some Unity event, call the function `StartDialogue` on the `DialogueBox` script. If you call `StartDialogue` again before the dialogue has fully displayed, it will complete the display of the current dialogue text. If you call it again, it will repeat the process.

To clear the dialogue window call the function `EndDialogue`.

### StartDialogue

```cs
    public void StartDialogue(Dialogue dialogue)
```

The `dialogue` parameter is a reference to the `Dialogue` scriptable object you wish to display.

### Text processing

```cs
    public delegate void TextProcessor(ref string text);
    public event TextProcessor PreProcessText;
```
To optionally apply processing to the dialogue text before display, you can subscribe to the `PreProcessText` event on the `DialogueBox` instance. This example code will capitalize the text before it is displayed:

```cs
    public void OnEnable()
    {
        dialogueBox.PreProcessText += CapitalizeText;
    }

    public void OnDisable()
    {
        dialogueBox.PreProcessText -= CapitalizeText;
    }

    private static void CapitalizeText(ref string text)
    {
        text = text.ToUpper();
    }
```

## Extending the component

You can add additional data to the `Character` or `Dialogue` scriptable objects.

The delay between characters could be randomized within a range to produce a more natural feel.

The audio clip could be randomized, pitch shifted, or special clips used for characters such as the space bar.
