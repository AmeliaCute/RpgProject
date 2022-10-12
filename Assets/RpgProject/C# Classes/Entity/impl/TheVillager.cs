using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class TheVillager : villager
{
    public override string name => "TheVillager";

    public override void interact() 
    {
        StartCoroutine(dialogue());
    }

    private IEnumerator dialogue()
    {
        yield return new WaitForEndOfFrame();

        int Choice = 0;

        yield return DialogueMan.Instance.ShowDialogue(
            new Dialogue("Le villageois", 
            new List<string>{ "Salut, je suis le villageois", "J'adore les pommes", "Blablabla" }, "Grand Maitre Mage"), 
            new List<string>{ "Aurevoir", "Argent ++", "TrucPasDrole" },
            (int choice) => Choice = choice
        );

        switch(Choice)
        {
            case 0:
                Debug.Log("Aurevoir");
                DialogueMan.Instance.CloseDialogue();
                break;

            case 1:
                Debug.Log("Argent ++");
                Player.GetPlayer().addMoney(100);
                DialogueMan.Instance.CloseDialogue();   
                break;

            case 2:
                Debug.Log("TrucPasDrole");
                DialogueMan.Instance.CloseDialogue();
                break;

            default: 
                break;
        }
    }
}