using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public List<string> dialogueText;

    public Dialogue(string name, List<string> dialogueText)
    {
        this.name = name;
        this.dialogueText = dialogueText;
    }

    public string Name { get { return name; } }
    public List<string> DialogueText { get { return dialogueText; } }
}