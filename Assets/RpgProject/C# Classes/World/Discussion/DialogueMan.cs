using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueMan : MonoBehaviour
{
    public GameObject DialogueBox;
    public GameObject ContDote;
    public Text DialogueText;
    public Text DialogueName;

    public event UnityAction OnShowDialogue;
    public event UnityAction OnCloseDialogue;

    public int CurrLine = 0;
    public Dialogue CurrentDialogue;
    public bool IsDialogueOpen = false;

    public static DialogueMan Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        OnShowDialogue?.Invoke();

        CurrentDialogue = dialogue;

        DialogueName.text = dialogue.Name;
        DialogueBox.SetActive(true);
        StartCoroutine(TypeDialogue(dialogue.DialogueText[0]));
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1") && !IsDialogueOpen)
        {
            ++CurrLine;
            if(CurrLine < CurrentDialogue.DialogueText.Count)
            {
                StartCoroutine(TypeDialogue(CurrentDialogue.DialogueText[CurrLine]));
            }
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
            yield return new WaitForSeconds(0.01f / 8);
        }
        IsDialogueOpen = false;
        ContDote.SetActive(true);
    }
}