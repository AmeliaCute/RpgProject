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

    public override void interact()
    {
        DialogueMan.Instance.ShowDialogue(new Dialogue("Le villageois", new List<string>
         { "Salut, je suis le villageois", 
        "Je suis utile pour tester les dialogues",
        "Je suis le villageois" }));
    }

    public override void update()
    {
    }
}