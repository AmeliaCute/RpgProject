using UnityEngine;
using UnityEngine.UI;

using RpgProject.UI;

class workbench : machine
{
    public override string name => "WORKBENCH";
    public override bool isInteractable => true;

    private bool menuOpen;
    
    public override void Interact() {
        if(!menuOpen)
        {
            menuOpen = true;
            Font Myriad = Resources.Load<Font>("Fonts/myriad");
            GameObject x = new GameObject("Workbench Menu");
            GameObject _base = new GameObject("Base");
            GameObject background = new GameObject("Background");

            Image bg0 = background.AddComponent<Image>();
            RectTransform bg1 = background.GetComponent<RectTransform>();

            Image ba0 = _base.AddComponent<Image>();
            RectTransform ba1 = _base.GetComponent<RectTransform>();

            bg1.position = new Vector3(Screen.width/2, Screen.height/2, 0);
            ba1.position = new Vector3(Screen.width/2, Screen.height/2, 0);  
            
            bg1.localScale = new Vector3(4000, 4000, 0);
            ba1.sizeDelta = new Vector2(1500, 920);

            bg0.color = new Color(000, 000, 000, 0.9f);
            ba0.color = new Color(58 / 255.0F, 58 / 255.0F, 58 / 255.0F, 1.0f); 

            background.transform.SetParent(x.transform);
            _base.transform.SetParent(x.transform);

            GameObject CloseButton = new GameObject("CloseButton");
            Button _CloseButton = CloseButton.AddComponent<Button>();
            Image __CloseButton = CloseButton.AddComponent<Image>();
            RectTransform CloseButton1 = CloseButton.GetComponent<RectTransform>();

            CloseButton1.sizeDelta = new Vector3(50,50);
            CloseButton1.position = new Vector3(960+710, 540 + 420, 0);

            _CloseButton.onClick.AddListener(closeMenu);

            ItemGraphique.itemIcon(new ItemComponent(Items.DEBUG_ITEM, 19), new Vector2(0,0), 128).transform.SetParent(ba0.transform);

            CloseButton.transform.SetParent(_base.transform);
            x.transform.SetParent(GameObject.Find("Canvas").transform);
            Gamestates.set(GameState.BUSY);
        }
    }

    public void closeMenu()
    {
        if(menuOpen)
        {
            menuOpen = false;
            Gamestates.set(GameState.PLAYING);
            Destroy(GameObject.Find("Workbench Menu"));
        }
    }
}