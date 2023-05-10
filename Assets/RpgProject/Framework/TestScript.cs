using UnityEngine;
using RpgProject.Framework.Graphics;
using RpgProject.Framework.Graphics.Overlays;
using System;
using Action = RpgProject.Framework.Graphics.Overlays.Action;
using RpgProject.Framework.Graphics.Screens;

public class TestScript : MonoBehaviour
{
    void Start()
    {

        Drawable.Create
        (
            DrawableType.Foreground,
            new Container
            {
                Color = new UnityEngine.Color(0.541f, 0.169f, 0.886f),
                Width = 14f,
                Height = 6f,
                Children = {
                    new BorderRoundedButton
                    {
                        Size = new Vector2(2.2f,5f),
                        Color = new Color(0.8f,0.8f,0.8f),
                        Sprite = Resources.Load<Sprite>("Sprites/Test/Banner/Banner_Wizard"),
                        Offset = new Vector2(-2, 0)
                    },
                    new BorderRoundedButton
                    {
                        Size = new Vector2(2.2f,5f),
                        Color = new Color(0.8f,0.8f,0.8f),
                        Sprite = Resources.Load<Sprite>("Sprites/Test/Banner/Banner_Blacksmith"),
                        Offset = new Vector2(-4.5f, 0)
                    },
                    new Container
                    {
                        Color = new UnityEngine.Color(0.5f,0.5f,0f),
                        Width = 4,
                        Height = 4.5f,
                        Offset = new UnityEngine.Vector2(3, 0),
                        Children = {
                            new RoundedButton
                            {
                                Label = "Il est beau le deuxieme bouton hein?",
                                Size = 1.2f,
                                Color = new UnityEngine.Color(0f,0f,0.553f),
                                Action = null,
                                Offset = new UnityEngine.Vector2(0, -1),
                            },
                            new RoundedButton
                            {
                                Label = "Show Starting menu",
                                Size = 1.2f,
                                Color = new UnityEngine.Color(0f,0f,0.553f),
                                Action = new ShowStartingMenu(),
                                Offset = new UnityEngine.Vector2(0,2),
                            },
                            new RoundedButton
                            {
                                Label = "Show Inventory menu",
                                Size = 1.2f,
                                Color = new UnityEngine.Color(0f,0f,0.553f),
                                Action = new ShowInventoryMenu(),
                                Offset = new UnityEngine.Vector2(0,0),
                            },
                            new RoundedButton
                            {
                                Label = "Show overlay",
                                Size = 1.2f,
                                Color = new UnityEngine.Color(0f,0f,0.553f),
                                Action = new ShowOverlay(),
                                Offset = new UnityEngine.Vector2(0,1),
                            }
                        }
                    }
                }
            }
        );
    }
}

class ShowOverlay : Action { public override void Start() { Drawable.ClearAll(); new HotbarOverlay();  } }
class ShowStartingMenu : Action { public override void Start() { Drawable.ClearAll(); new StartingMenu();  } }

class ShowInventoryMenu : Action { public override void Start() { Drawable.ClearAll(); new InventoryMenu();  } }