using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    public Image BossHealth;
    public Text BossText;

    private float MaxHealth;
    private float CurrentHealth;
    private bool Active;

    public static BossBar Instance { get; set; }
    private void Awake() { Instance = this; }

    public void SetBossBar(string name, float health)
    {
        MaxHealth = health;
        CurrentHealth = health;
        BossText.text = name;
    }

    public void SetHealth(float health)
    {
        CurrentHealth = health;
    }

    public void SetActive(bool active)
    {
        gameObject.active = active;
        Active = active;
    }

    private void Update() 
    {
        float hel = ((CurrentHealth * 100) / MaxHealth) / 100;
        BossHealth.fillAmount = hel;
    }
}