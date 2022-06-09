using UnityEngine;

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
        Debug.LogError("Npc: "+name+" say hi");
    }

    public override void update()
    {
    }
}