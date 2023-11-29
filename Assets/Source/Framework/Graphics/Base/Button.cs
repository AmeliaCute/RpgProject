using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RpgProject.FrameworkV2
{
    partial class Button : Bordered
    {
        public UnityEngine.UI.Button ButtonComponent { get; protected set; } = null;
        public bool Intereactable { get; set; } = true;
        public float FadeDuration { get; set; } = .1f;
        public UnityAction OnClickActions { get; set; } = null;
        public Color32 HoverColor { get; set; } = new(255,255,255,255); 
        public Color32 PressedColor { get; set; } = new(150,150,150,255); 
        public Color32 DisabledColor { get; set; } = new(50,50,50,200); 
        public int ColorMultiplier { get; set; } = 1;


        public override GameObject Create()
        {
            base.Create();
            
            ButtonComponent = Object.AddComponent<UnityEngine.UI.Button>();
            UpdateClickActions(OnClickActions);
            UpdateColorBlock(HoverColor, Color, PressedColor, DisabledColor, FadeDuration, ColorMultiplier);

            return Object;
        }

        public void UpdateClickActions(UnityAction action)
        {
            if (ButtonComponent != null && action != null)
            {
                OnClickActions = action;
                ButtonComponent.onClick.AddListener(action);
            }
        }
        
        // Shity block
        public void UpdateColorBlock(Color32 normal, Color32 hover, Color32 pressed, Color32 disabled, float fadeDuration, int colorMultiplier)
        {
            if (ButtonComponent != null)
            {
                Color = normal;
                HoverColor = hover;
                PressedColor = pressed; 
                DisabledColor = disabled;
                FadeDuration = fadeDuration;
                ColorMultiplier = colorMultiplier;

                UnityEngine.UI.ColorBlock colors = new()
                {
                    fadeDuration = fadeDuration,
                    disabledColor = disabled,
                    normalColor = normal,
                    selectedColor = normal,
                    highlightedColor = hover,
                    colorMultiplier = colorMultiplier
                };

                ButtonComponent.colors = colors;
            }
        }
    }
}