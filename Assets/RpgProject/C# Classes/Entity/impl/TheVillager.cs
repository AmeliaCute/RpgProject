using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class TheVillager : villager
{
    public TheVillager() : base("Le villageois", 150f)
    { }

    public override void die()
    {
        Destroy(gameObject);
    }

    public override void init()
    {
    }

    public override NpcState DefState() {return NpcState.IDLE;}

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
            new List<string>{ "Salut, je suis le villageois" }), 
            new List<string>{ "Aurevoir", "Saucisse", "TrucPasDrole" },
            (int choice) => ChoiSel = choice
        );

        if(ChoiSel == 0)
        {
            Debug.Log("Aurevoir");
            DialogueMan.Instance.CloseDialogue();
        }
        else if(ChoiSel == 1)
        {
            Debug.Log("Saucisse");
            DialogueMan.Instance.CloseDialogue();
        }
        else if(ChoiSel == 2)
        {
            Debug.Log("TrucPasDrole");
            DialogueMan.Instance.CloseDialogue();
        }
    }
}