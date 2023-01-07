using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoiceBox : MonoBehaviour
{
    public ChoiceText ChoiTexPref;
    private bool ChoiceSelect = false;

    private List<ChoiceText> choiceTexts;
    private int CurrChoice;

    private float CurrentCooldown;

    public IEnumerator ShowChoices(List<string> choices, Action<int> onChoiceSelect)
    {
        ChoiceSelect = false;
        gameObject.SetActive(true); 

        CurrChoice = 0;

        foreach (Transform child in transform)
            Destroy(child.gameObject);

        choiceTexts = new List<ChoiceText>();
        for(int i = 0; i < choices.Count; ++i)
        {
            var choiceText = Instantiate(ChoiTexPref, transform);
            choiceText.gameObject.transform.position = new Vector3(choiceText.gameObject.transform.position.x,100 + (i * 80), choiceText.gameObject.transform.position.z);
            choiceText.setText(choices[i]);
            choiceText.Update();

            choiceTexts.Add(choiceText);
        }

        yield return new WaitUntil(() => ChoiceSelect == true);
        
        onChoiceSelect?.Invoke(CurrChoice);

        gameObject.SetActive(false);
    }

    private void Start() {
        CurrentCooldown = Time.time;
    }

    private void Update()
    {
        float AxisVer = Input.GetAxisRaw("Vertical");
        float actionCooldown = 0.1f;

        if (Time.time > CurrentCooldown)
        {
            if(AxisVer > 0.95) 
                if(CurrChoice < choiceTexts.Count - 1) 
                    ++CurrChoice;

            if(AxisVer < -0.95) 
                if(CurrChoice > 0) 
                    --CurrChoice;

            CurrentCooldown = Time.time + actionCooldown;
        }

        CurrChoice = Mathf.Clamp(CurrChoice, 0, choiceTexts.Count - 1);

        for(int i = 0; i < choiceTexts.Count; ++i) choiceTexts[i].setSelected(i == CurrChoice);

        if(Input.GetButtonUp("Fire1")) ChoiceSelect = true;
    }
}