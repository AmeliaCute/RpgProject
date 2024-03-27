using UnityEngine;
using UnityEngine.Events;

public class EnduranceTaskEntity : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public EnduranceTaskSystem enduranceTaskSystem;
    public ItemInstance itemInstance;
    public Statistic defense = new Statistic(10, 0);
    public Statistic health = new Statistic(10, 0);

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnDamage()
    {
        animator.Play("OreDamage");
    }

    public void OnDeath()
    {
        GameObject drop = Instantiate(Resources.Load<GameObject>("Prefab/PseudoEntity/DropableTest"));
        drop.GetComponent<DropTest>().items = itemInstance;
        drop.transform.position = new(transform.position.x, 0.3f, transform.position.z);
        Destroy(gameObject, 0.19f);
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