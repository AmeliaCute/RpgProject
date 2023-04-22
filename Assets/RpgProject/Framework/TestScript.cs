using UnityEngine;
using RpgProject.Framework.Graphics;
using RpgProject.Framework.Graphics.Overlays;
using System;
using Action = RpgProject.Framework.Graphics.Overlays.Action;
using RpgProject.Framework.Graphics.Screens;

public class TestScript : MonoBehaviour
{
    void Awake()
    {

        Drawable.Create
        (
            new Container
            {
                Color = new UnityEngine.Color(0.541f, 0.169f, 0.886f),
                Width = 14f,
                Height = 6f,
                Children = {
                    new RoundedButton
                    {
                        Label = "Coucou j'adore les pommes et vous? sfsnkfs sjkfsf lsekrfj lksejf",
                        Size = 1f,
                        Color = new UnityEngine.Color(0,0,0),
                        Action = null,
                        Offset = new UnityEngine.Vector2(-2, 2),
                        Margin = 5f
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
                                Label = "(TEST) CharactereConfig",
                                Size = 1.2f,
                                Color = new UnityEngine.Color(0f,0f,0.553f),
                                Action = null,
                                Offset = new UnityEngine.Vector2(0,2),
                            },
                            new TabBarButton
                            {
                                Label = "",
                                Size = 0.8f,
                                Color = new UnityEngine.Color(0f,0f,0.553f),
                                Action = new OpenConfig(),
                                Offset = new UnityEngine.Vector2(0,1),
                            }
                        }
                    }
                }
            }
        );
    }
}

class OpenConfig : Action { public override void Start() { Drawable.Clear(); new CharacterConfig();  } }
