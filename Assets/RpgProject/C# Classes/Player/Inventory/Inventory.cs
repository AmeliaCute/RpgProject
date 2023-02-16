using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using RpgProject.Objects;
using RpgProject.UI;

public enum Categories
{
    ALL,
    CONSUMABLE,
    CRAFTING,
    JOB,
    WEAPON,
    ARMOR,
    QUEST,
    OTHER
}

public class Inventory : MonoBehaviour
{
    private List<GameObject> objects;
    private GameObject playerModel;
    private Inventory instance;
    private List<Item> items;
    public Sword weapon = null;
    public Pickaxe pickaxe = null;

    public const int INITIAL_HEIGHT = 585;
    public const int INITIAL_WIDTH = 40;
    public const int ICON_SIZE = 128;
    public const int X_SPACING = 0;
    public const int Y_SPACING = 0;

    private bool isOpen = false;

    private Canvas hud;
    private Canvas inventory;
    private Camera uiCamera;
    private Player player;
    //TODO Mettre un slot spécifique pour chaque métier
    
    public Font Myriad;

    public List<Item> GetItems() { return items; }
    public Item GetItem(Item item) { return items.Find(x => x == item); }
    public Sword getWeapon() { return weapon; }
    public Pickaxe getPickaxe() { return pickaxe; }

    public void AddItem(Item item) { items.Add(item); } 
    public void RemoveItem(Item item) { items.Remove(item); }
    
    public bool IsOpen() { return isOpen; }

    public void ToggleInventory() {
        isOpen = !isOpen;
        inventory.enabled = isOpen;
        if (!isOpen)
            HideInventory();
        else {
            Gamestates.set(GameState.BUSY);
            DisplayInventory();
            DisplayPlayerModel();
            DisplayStats();
        }
    }

    private void Start() {
        objects = new List<GameObject>();
        player = Player.GetPlayer();
        inventory = GameObject.Find("Inventory").GetComponent<Canvas>();
        hud = GameObject.Find("Hud").GetComponentInChildren<Canvas>();
        uiCamera = GameObject.Find("UI Camera").GetComponent<Camera>();
        InventoryStats.AddBonusToStat("Strength",  weapon != null ? weapon.getDamage() : 0);
        Myriad = Resources.Load<Font>("Fonts/myriad");
    }

    private void DisplayInventory() {
        for (int i = 0; i < items.Count; ++i) {
            GameObject icon = new GameObject("inventory_slot_" + i);
            Vector3 pos = icon.transform.position;
            icon.transform.SetParent(inventory.transform);
            icon.AddComponent<Image>();
            icon.layer = LayerMask.NameToLayer("UI");
            icon.GetComponent<Image>().sprite = items[i].getIcon();
            RectTransform rectTransform = icon.GetComponent<RectTransform>();
            pos.y += INITIAL_HEIGHT - (i / 10) * (rectTransform.rect.height + Y_SPACING);
            pos.x += INITIAL_WIDTH + (i % 10) * (rectTransform.rect.width + X_SPACING);
            icon.GetComponent<RectTransform>().position = pos;
            Debug.Log(rectTransform.rect.width.ToString());
            objects.Add(icon);
        }
        hud.enabled = false;
        uiCamera.enabled = true;
    }

    private void DisplayPlayerModel() {
        playerModel = Instantiate(GameObject.Find("Model"));
        playerModel.name = "player_model";
        playerModel.transform.SetParent(inventory.transform);
        ObjectManipulation.SetLayerRecursively(playerModel, LayerMask.NameToLayer("UI"));
        Vector3 pos = playerModel.transform.position;
        Vector3 scale = playerModel.transform.localScale;
        Vector3 rotation = playerModel.transform.eulerAngles;
        pos.x += 10;
        pos.y += 450;
        pos.z -= 350;
        rotation.y = 75;
        scale.x = 95;
        scale.y = 95;
        scale.z = 95;
        playerModel.transform.localScale = scale;
        playerModel.transform.position = pos;
        playerModel.transform.rotation = Quaternion.Euler(rotation);
    }

    private void DisplayStats() {
        for (int i = 0; i < InventoryStats.stats.Count; ++i) {
            Stat stat = InventoryStats.stats[i];
            GameObject label = new GameObject("stat_" + stat.getName().ToLower() + "_label");
            GameObject value = new GameObject("stat_" + stat.getName().ToLower() + "_value");
            Text labelText = label.AddComponent<Text>();
            Text valueText = value.AddComponent<Text>();
            ContentSizeFitter labelFitter = label.AddComponent<ContentSizeFitter>();
            ContentSizeFitter valueFitter = value.AddComponent<ContentSizeFitter>();
            Vector3 labelPos = label.transform.position;
            Vector3 valuePos = value.transform.position;
            RectTransform labelTransform = label.GetComponent<RectTransform>();
            RectTransform valueTransform = value.GetComponent<RectTransform>();
            labelTransform.pivot = new Vector2(0, 0.5f);
            valueTransform.pivot = new Vector2(0, 0.5f);
            labelPos.x -= 400;
            labelPos.y += 175 - 33.5f * i;
            valuePos.x -= 270;
            valuePos.y += 175 - 33.5f * i;
            labelText.transform.position = labelPos;
            valueText.transform.position = valuePos;
            labelFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            valueFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            labelText.text = stat.getName();
            valueText.text = stat.BaseValue.ToString();
            labelText.font = Myriad;
            valueText.font = Myriad;
            labelText.fontSize = 20;
            valueText.fontSize = 20;
            labelText.fontStyle = FontStyle.Italic;
            labelText.alignment = TextAnchor.MiddleLeft;
            valueText.alignment = TextAnchor.MiddleLeft;
            label.transform.SetParent(inventory.transform);
            value.transform.SetParent(inventory.transform);
            label.layer = LayerMask.NameToLayer("UI");
            value.layer = LayerMask.NameToLayer("UI");
            if (stat.Bonus != 0) {
                LayoutRebuilder.ForceRebuildLayoutImmediate(valueTransform);
                DisplayBonus(stat, 175 - 33.5f * i, valueTransform.rect.width);
            }
            objects.Add(label);
            objects.Add(value);
        }
        DisplayOtherStats();
    }

    private void DisplayBonus(Stat stat, float y, float width) {
        GameObject bonus = new GameObject("stat_" + stat.getName().ToLower() + "_bonus");
        Text bonusText = bonus.AddComponent<Text>();
        ContentSizeFitter bonusFitter = bonus.AddComponent<ContentSizeFitter>();
        RectTransform bonusTransform = bonus.GetComponent<RectTransform>();
        Vector3 bonusPos = bonus.transform.position;
        Debug.Log(width);
        bonusTransform.pivot = new Vector2(0, 0.5f);
        bonusPos.x -= 270 - width - 5;
        bonusPos.y += y;
        bonusFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        bonusFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        bonusText.font = Myriad;
        bonusText.fontSize = 20;
        if (stat.Bonus > 0) {
            bonusText.color = Color.green;
            bonusText.text = "+" + stat.Bonus.ToString();
        } else {
            bonusText.color = Color.red;
            bonusText.text = stat.Bonus.ToString();
        }
        bonusText.transform.position = bonusPos;
        bonus.transform.SetParent(inventory.transform);
        bonus.layer = LayerMask.NameToLayer("UI");
        objects.Add(bonus);
    }

    private void DisplayOtherStats() {
        GameObject name = new GameObject("name_label");
        GameObject money = new GameObject("money_label");
        Text nameText = name.AddComponent<Text>();
        Text moneyText = money.AddComponent<Text>();
        ContentSizeFitter nameFitter = name.AddComponent<ContentSizeFitter>();
        ContentSizeFitter moneyFitter = money.AddComponent<ContentSizeFitter>();
        Vector3 namePos = name.transform.position;
        Vector3 moneyPos = money.transform.position;
        RectTransform moneyTransform = money.GetComponent<RectTransform>();
        moneyTransform.pivot = new Vector2(0, 0.5f);
        namePos.x -= 375;
        namePos.y -= 67.5f;
        moneyPos.y -= 67.5f;
        moneyPos.x -= 245;
        nameText.transform.position = namePos;
        moneyText.transform.position = moneyPos;
        nameText.font = Myriad;
        moneyText.font = Myriad;
        nameText.text = player.name;
        moneyText.text = player.money.ToString();
        nameText.fontSize = 20;
        moneyText.fontSize = 20;
        nameFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        moneyFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        name.transform.SetParent(inventory.transform);
        money.transform.SetParent(inventory.transform);
        name.layer = LayerMask.NameToLayer("UI");
        money.layer = LayerMask.NameToLayer("UI");
        objects.Add(name);
        objects.Add(money);
    }

    private void HideInventory() {
        foreach (GameObject obj in objects)
            Destroy(obj);
        hud.enabled = true;
        uiCamera.enabled = false;
        Gamestates.set(GameState.PLAYING);
        Destroy(playerModel);
        objects.Clear();
    }

    private void Update() {
        if (!isOpen) return;
        //TODO Quand le joueur intéragie avec l'inventaire ;d
    }
}