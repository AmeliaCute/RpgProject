using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public string entitySubtitle;
    public List<string> dialogueText;

    public Dialogue(string name, List<string> dialogueText, string entitySubtitle = "")
    {
        this.name = name;
        this.dialogueText = dialogueText;
        this.entitySubtitle = entitySubtitle;
    }

    public string Name { get { return name; } }
    public List<string> DialogueText { get { return dialogueText; } }
    public string EntitySubtitle { get { return entitySubtitle; } }
}