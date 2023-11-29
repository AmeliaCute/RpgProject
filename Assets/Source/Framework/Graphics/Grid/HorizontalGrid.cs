using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.FrameworkV2 
{
    class HorizontalGrid : Bordered
    {
        public HorizontalLayoutGroup LayoutGroup { get; protected set; } = null;
        public virtual bool ChildControlHeight { get; set; } = false;
        public virtual bool ChildControlWidth { get; set; } = false;
        public virtual bool ChildForceExpandHeight { get; set; } = false;
        public virtual bool ChildForceExpandWidth { get; set; } = false;
        public virtual TextAnchor ChildsAlignement { get; set; } = TextAnchor.UpperLeft;
        public virtual bool ReverseArrangement { get; set; } = false;
        public virtual int Spacing { get; set; } = 0;
        public virtual RectOffset Padding { get; set; } = new(0, 0, 0, 0);

        public override GameObject Create()
        {
            base.Create();
            LayoutGroup = Object.AddComponent<HorizontalLayoutGroup>(); 

            UpdateChildForceExpand(ChildForceExpandHeight, ChildForceExpandWidth);
            UpdateChildControl(ChildControlWidth, ChildControlHeight);
            UpdateChildAlignement(ChildsAlignement);
            UpdatePadding(Padding);
            UpdateSpacing(Spacing);
            UpdateArrangement(ReverseArrangement);

            return Object;
        }

        public void UpdateChildAlignement(TextAnchor alignement)
        {
            if(LayoutGroup != null && LayoutGroup.childAlignment != alignement)
            {
                ChildsAlignement = alignement;
                LayoutGroup.childAlignment = alignement;
            }
        }

        public void UpdateArrangement(bool b)
        {
            if(LayoutGroup != null && LayoutGroup.reverseArrangement != b)
            {
                ReverseArrangement = b;
                LayoutGroup.reverseArrangement = b;
            }
        }

        public void UpdatePadding(RectOffset padding)
        {
            if(LayoutGroup != null && LayoutGroup.padding != padding)
            {
                Padding = padding;
                LayoutGroup.padding = padding;
            }
        }

        public void UpdateChildControl(bool width, bool height)
        {
            ChildControlHeight = height;
            ChildControlWidth = width;
            if (LayoutGroup != null)
            {
                LayoutGroup.childControlHeight = height;
                LayoutGroup.childControlWidth = width;
            }
        }

        public void UpdateChildForceExpand(bool width, bool height)
        {
            ChildForceExpandHeight = height;
            ChildForceExpandWidth = width;
            if (LayoutGroup != null)
            {
                LayoutGroup.childForceExpandHeight = height;
                LayoutGroup.childForceExpandWidth = width;
            }
        }

        public void UpdateSpacing(int space)
        {
            if(LayoutGroup != null && LayoutGroup.spacing != space)
            {
                Spacing = space;
                LayoutGroup.spacing = space;
            }
        }
    }
}