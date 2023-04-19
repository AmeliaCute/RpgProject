using UnityEngine;

abstract class ore : MonoBehaviour
{   
    public string _name;
    public float maxHealth;
    public float currentHealth;
    public bool destructed = false;

    public ore(string name, float health)
    {
        this._name = name;
        this.maxHealth = health;
    }

    void Start()
    {
        currentHealth = maxHealth;
        gameObject.transform.tag = "Ore";
    }


    public void Damage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            destructed = true;
            Die();
        }
    }

    public abstract void Die();

}
