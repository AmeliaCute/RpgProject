using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using RpgProject.Objects;

public enum QuestType{
    PVP,
    PVE,
    INTERACTION,
    EXPLORATION,
    LOOTING,
}

[CreateAssetMenu(fileName = "Quest", menuName = "RpgProject/Quest")]
public class Quest : ScriptableObject {

    public new string name;
    public QuestType questType;
    public string description;
    public Item[] rewards;

    public void showQuest()
    {
        Player.instance.isCheckingQuest = true;
        Font Myriad = Resources.Load<Font>("Fonts/myriad");
        GameObject x = new GameObject("QuestDetails");
        GameObject _base = new GameObject("Base");
        GameObject background = new GameObject("Background");

        Image bg0 = background.AddComponent<Image>();
        RectTransform bg1 = background.GetComponent<RectTransform>();

        Image ba0 = _base.AddComponent<Image>();
        RectTransform ba1 = _base.GetComponent<RectTransform>();

        bg1.position = new Vector3(Screen.width/2, Screen.height/2, 0);
        ba1.position = new Vector3(Screen.width/2, Screen.height/2, 0);  
        
        bg1.localScale = new Vector3(4000, 4000, 0);
        ba1.sizeDelta = new Vector2(535, 820);

        bg0.color = new Color(000, 000, 000, 0.9f);
        ba0.color = new Color(58 / 255.0F, 58 / 255.0F, 58 / 255.0F, 1.0f); 

        GameObject _Title = new GameObject("WindowTitle");
        Text ti0 = _Title.AddComponent<Text>();
        RectTransform ti1 = _Title.GetComponent<RectTransform>();
        
        ti0.color = new Color(255 / 255.0F, 228 / 255.0F, 184 / 255.0F, 1.0f); 
        ti0.text = "Quete";
        ti0.font = Myriad;
        ti0.fontSize = 33;
        ti0.alignment  = TextAnchor.MiddleCenter;
        ti1.position = new Vector3(960, 540 + 361.5F, 0);  


        GameObject _Name = new GameObject("Name");
        Text na0 = _Name.AddComponent<Text>();
        RectTransform na1 = _Name.GetComponent<RectTransform>();
        
        na0.color = new Color(255,255,255,1); 
        na0.text = name;
        na0.font = Myriad;
        na0.fontSize = 25;
        na0.alignment  = TextAnchor.MiddleCenter;
        na1.position = new Vector3(960, 540 + 316.5F, 0);  
        na1.sizeDelta = new Vector2(426, 30);


        GameObject description_label = new GameObject("description_label");
        Text dl0 = description_label.AddComponent<Text>();
        RectTransform dl1 = description_label.GetComponent<RectTransform>();
        
        dl0.color = new Color(255,255,255,1); 
        dl0.text = "description:";
        dl0.font = Myriad;
        dl0.fontSize = 22;
        dl1.position = new Vector3(960, 540 + 215.5F, 0);  
        dl1.sizeDelta = new Vector2(426, 30);


        GameObject description_value = new GameObject("description_value");
        Text dv0 = description_value.AddComponent<Text>();
        RectTransform dv1 = description_value.GetComponent<RectTransform>();
        
        dv0.color = new Color(255,255,255,1); 
        dv0.text = description;
        dv0.font = Myriad;
        dv0.fontSize = 22;
        dv1.position = new Vector3(960, 540 + 105, 0);  
        dv1.sizeDelta = new Vector2(426, 185);

        
        GameObject rewards_label = new GameObject("rewards_label");
        Text rl0 = rewards_label.AddComponent<Text>();
        RectTransform rl1 = rewards_label.GetComponent<RectTransform>();
        
        rl0.color = new Color(255,255,255,1); 
        rl0.text = "recompense(s):";
        rl0.font = Myriad;
        rl0.fontSize = 22;
        rl1.position = new Vector3(960, 540 + -26.15F, 0);  
        rl1.sizeDelta = new Vector2(426, 30);

        background.transform.SetParent(x.transform);
        _base.transform.SetParent(x.transform);

        _Title.transform.SetParent(_base.transform);
        _Name.transform.SetParent(_base.transform);
        description_label.transform.SetParent(_base.transform);
        description_value.transform.SetParent(_base.transform);
        rewards_label.transform.SetParent(_base.transform);

        x.transform.SetParent(GameObject.Find("Canvas").transform);
        Gamestates.set(GameState.BUSY);
    }

    public static void hideQuest()
    {
        if(Player.instance.isCheckingQuest)
            Gamestates.set(GameState.PLAYING);
            GameObject.Destroy(GameObject.Find("QuestDetails"));
            Player.instance.isCheckingQuest = false;
    }
}