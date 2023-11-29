using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.FrameworkV2
{
    partial class Scrollable : DrawableObject
    {
        public ScrollRect ScrollRect { get; protected set; } = null;
        public bool Horizontal { get; set; } = false;
        public bool Vertical { get; set; } = true;
        public bool Inertia { get; set; } = true;
        public float Deceleration { get; set; } = .1f;
        public float ScrollSensitivity { get; set; } = 5;
        public float Elasticity { get; set; } = .1f;

        public override GameObject Create()
        {
            base.Create();

            //! need a cleaning
            ScrollRect = Object.AddComponent<ScrollRect>();
            Image image = Object.AddComponent<Image>();
            image.color = new Color(0,0,0,1);
            
            Object.AddComponent<Mask>();

            UpdateHoriVerti(Horizontal,Vertical);    
            UpdateScrollManagement(Deceleration,ScrollSensitivity,Elasticity,Inertia);

            GameObject ScrollPane = new GameObject("ViewPane");
            RectTransform ScrollPaneRectTransform = ScrollPane.AddComponent<RectTransform>();

            float sizeY = 0;
            foreach(DrawableObject drawable in Children)
                sizeY =+ drawable.Size.y;

            ScrollPaneRectTransform.sizeDelta = new(Size.x, Size.y);
            ScrollPaneRectTransform.position = ConvertVectorToUniversalDim(Position);

            ScrollRect.content = ScrollPaneRectTransform;
            ScrollPane.transform.SetParent(Object.transform, false);

            Parent = ScrollPane;
            return Object;
        }

        public void UpdateHoriVerti(bool horizontal, bool vertical)
        {
            if (ScrollRect != null)
            {
                Horizontal = horizontal;
                Vertical = vertical;
                ScrollRect.horizontal = Horizontal;
                ScrollRect.vertical = Vertical;
            }
        }

        public void UpdateScrollManagement(float deceleration, float scrollSensitivity, float elasticity, bool inertia)
        {
            if (ScrollRect != null)
            {
                Deceleration = deceleration;
                ScrollSensitivity = scrollSensitivity;
                Elasticity = elasticity;
                Inertia = inertia;

                ScrollRect.decelerationRate = Deceleration;
                ScrollRect.scrollSensitivity = ScrollSensitivity;
                ScrollRect.elasticity = Elasticity;
                ScrollRect.inertia = Inertia;
            }
        }
    }
}