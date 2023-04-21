using System.Diagnostics;
using System.Numerics;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RpgProject.Framework.Graphics;
using RpgProject.Framework.Graphics.Overlays;
using System;
using System.Threading;
using System.Threading.Tasks;

public class TestScript : MonoBehaviour
{
    void Start()
    {
        Action<object> action = (object obj) =>
        {
            UnityEngine.Debug.Log("T'es tilté boubou");
        };
        
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
                        Action = action,
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
                                Action = action,
                                Offset = new UnityEngine.Vector2(0, -1),
                            }
                        }
                    }
                }
            }
        );
    }
}
