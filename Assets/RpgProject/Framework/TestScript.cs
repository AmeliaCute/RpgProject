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
                Size = new UnityEngine.Vector2(1504, 1045),
                Children = {
                    new Button
                    {
                        Label = "Coucou j'adore les pommes et vous?",
                        Size = new UnityEngine.Vector2(1.5f, 1f),
                        Color = new UnityEngine.Color(0,0,0),
                        Action = action
                    }
                }
            }
        );
    }
}
