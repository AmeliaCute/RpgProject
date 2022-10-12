using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueMan : MonoBehaviour
{
    public GameObject DialogueBox;
    public ChoiceBox choiceBox;
    public GameObject ContDote;
    public Text DialogueText;
    public Text DialogueName;
    public Text DialogueEntitySubtitle;

    public event UnityAction OnShowDialogue;
    public event UnityAction OnCloseDialogue;

    public int CurrLine = 0;
    public Dialogue CurrentDialogue;
    public bool IsDialogueOpen = false;
    public bool IsChoiceOpen = false;

    public bool hasChoices = false;

    public static DialogueMan Instance { get; private set; }

    private void Awake() { Instance = this; }

    //FIXME: C'est d'la merde
    public IEnumerator ShowDialogue(Dialogue dialogue, List<string> choices=null, Action<int> onChoiceSelect=null)
    {
        yield return new WaitForEndOfFrame();

        OnShowDialogue?.Invoke();

        CurrentDialogue = dialogue;

        DialogueName.text = dialogue.Name;
        DialogueEntitySubtitle.text = dialogue.EntitySubtitle;
        DialogueBox.SetActive(true);

        hasChoices = false;

        StartCoroutine(TypeDialogue(dialogue.DialogueText[0]));
        yield return new WaitForEndOfFrame();

        if(choices != null && choices.Count > 1) 
        {
            hasChoices = true;
            IsChoiceOpen = true;
            yield return choiceBox.ShowChoices(choices, onChoiceSelect);
            IsChoiceOpen = false;
        } 
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1") && !IsDialogueOpen && !IsChoiceOpen)
        {
            ++CurrLine;
            if(CurrLine < CurrentDialogue.DialogueText.Count) StartCoroutine(TypeDialogue(CurrentDialogue.DialogueText[CurrLine]));
            else
            {
                CurrLine = 0;
                DialogueBox.SetActive(false);
                ContDote.SetActive(false);
                OnCloseDialogue?.Invoke();
            }
        }
    }

    public IEnumerator TypeDialogue(string dialogue)
    {
        IsDialogueOpen = true;
        
        ContDote.SetActive(false);
        DialogueText.text = "";
        foreach (char letter in dialogue.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(0.01f / 32);
        }
        IsDialogueOpen = false;
        if(!hasChoices)
            ContDote.SetActive(true);
    }

    public void CloseDialogue()
    {
        CurrLine = 0;
        DialogueBox.SetActive(false);
        ContDote.SetActive(false);
        OnCloseDialogue?.Invoke();
    }
}