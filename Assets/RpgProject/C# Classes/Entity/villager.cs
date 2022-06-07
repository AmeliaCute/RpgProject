using UnityEngine;

abstract class villager : Monobehaviour 
{

    public string _name;
    public float health;

    /// <summary>
    /// The constructor of the villager class
    /// </summary>
    /// <param name="_name"> parameter to define the name of the npc </param>
    /// <param name="health"> parameter can be used like when the player is attacking for no reason a poor villager </param>
    public villager(string _name, float health)
    {
        this._name = _name;
        this.health = health;
    }

    public string Name { get { return _name; } set { _name = value; } }
    public float Health { get { return health; } set { health = value; } }

    /// <summary>
    /// Function to decrease the health of the npc
    /// </summary>
    /// <param name="damage"></param>
    public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            health = 0;
            die();
        }
    }

    public abstract void interact();
    public abstract void init();
    public abstract void die();
}