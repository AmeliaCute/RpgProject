using UnityEngine;
using UnityEngine.Events;

public class EnduranceTaskEntity : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public EnduranceTaskSystem enduranceTaskSystem;
    public ItemInstance itemInstance;
    public Statistic defense = new Statistic(10, 0);
    public Statistic health = new Statistic(100, 0);

    public void OnDamage()
    {

    }

    public void OnDeath()
    {
        GameObject drop = Instantiate(Resources.Load<GameObject>("Prefab/DropableTest"));
        drop.GetComponent<DropTest>().items = itemInstance;
        drop.transform.position = transform.position;
        Destroy(gameObject, 1.5f);
    }

    public void Damage(float damage)
    {
        health.bonusValue -= damage;
        OnDamage();
        if (health.TotalValue <= 0)
        {
            OnDeath();  
            enduranceTaskSystem.Finish();
        }
    }

    
}