using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class oddodod : villager
{
    /*public TheVillager() : base("Le villageois", 150f)
    { }

    public override void die()
    {
        Destroy(gameObject);
    }

    public override void init()
    {
    }

    public override void interact()
    {
        StartCoroutine(dial());
    }

    public override void update()
    {
    }

    private IEnumerator dial()
    {
        yield return new WaitForEndOfFrame();

        int ChoiSel = 0;
        yield return DialogueMan.Instance.ShowDialogue(
            new Dialogue("Le villageois", 
            new List<string>{ "Salut, je suis le villageois" }, "Grand Maitre Mage"), 
            new List<string>{ "Aurevoir", "Argent ++", "TrucPasDrole" },
            (int choice) => ChoiSel = choice
        );

        if(ChoiSel == 0)
        {
            Debug.Log("Aurevoir");
            DialogueMan.Instance.CloseDialogue();
        }
        else if(ChoiSel == 1)
        {
            Debug.Log("Argent ++");
            Player.GetPlayer().addMoney(100);
            DialogueMan.Instance.CloseDialogue();
        }
        else if(ChoiSel == 2)
        {
            Debug.Log("TrucPasDrole");
            DialogueMan.Instance.CloseDialogue();
        }
    }*/
}