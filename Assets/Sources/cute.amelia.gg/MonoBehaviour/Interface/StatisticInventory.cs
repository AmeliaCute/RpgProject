using UnityEngine;
using UnityEngine.UI;

public class StatisticInventory : MonoBehaviour
{
    [SerializeField] private Text addedDef;
    [SerializeField] private Text addedAtk;
    [SerializeField] private Text addedSpd;
    [SerializeField] private Text baseDef;
    [SerializeField] private Text baseAtk;
    [SerializeField] private Text baseSpd;
    [SerializeField] private Text totalDef;
    [SerializeField] private Text totalAtk;
    [SerializeField] private Text totalSpd;
    [SerializeField] private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        addedDef.text = $"{player.defense.bonusValue}";
        addedAtk.text = $"{player.attack.bonusValue}";
        addedSpd.text = $"{player.speed.bonusValue * 10}";

        baseDef.text = $"{player.defense.baseValue}";
        baseAtk.text = $"{player.attack.baseValue}";
        baseSpd.text = $"{player.speed.baseValue * 10}";

        totalDef.text = $"{player.defense.TotalValue}";
        totalAtk.text = $"{player.attack.TotalValue}";
        totalSpd.text = $"{player.speed.TotalValue * 10}";
    }
}