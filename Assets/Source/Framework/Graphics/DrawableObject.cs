using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace RpgProject.FrameworkV2
{
    partial class DrawableObject 
    {
        public Vector2 Size { get; set; } = new (1,1);
        public Vector2 Position { get; set; } = new (0,0);
        public List<DrawableObject> Children { get; set; } = new List<DrawableObject>();

        //! All objects need to get a unique identifier if there are in the same panel
        public string Identifier { get; set; } = "object";
        
        public GameObject Object { get; protected set; } = null;
        public RectTransform RectTransform { get; protected set; } = null;
        
        //* Dont touch it, except for really specific cases.
        public GameObject Parent = null;

        public GameObject CreateGameObject(GameObject parent)
        {
            GameObject gameObject = Create();
            gameObject.transform.SetParent(parent.transform, false);
            CreateChildren(Parent == null ? Object : Parent);
            return gameObject;
        }
        public virtual GameObject Create()
        {
            
            Object = new(Identifier);
            RectTransform = Object.AddComponent<RectTransform>();
            UpdateObjectPosition();
            UpdateObjectSize();
            

            return Object;
        }

        public void Attach(GameObject parent, params DrawableObject[] attachs)
        {
            if(parent == null)
            {
                RpgClass.LOGGER.Error("You can't attach something to a inexistant parent or object");
                return;
            } 
            foreach(DrawableObject child in attachs)
                child?.CreateGameObject(parent);

            Children.AddRange(attachs);
        }

        public void Attach(params DrawableObject[] attachs)
        {
            Attach(Object, attachs);
        }

        public void CreateChildren(GameObject parent)
        {
            if(Children != null)
                foreach(DrawableObject child in Children)
                    child.CreateGameObject(parent);
        }

        public void CreateChildren()
        {
            CreateChildren(Object);
        }

        public void UpdateObjectSize()
        {
            if(Object != null && Object.transform.localScale != new Vector3(Size.x, Size.y, 1))
            {
                Size = ConvertVectorToUniversalDim(Size);
                RectTransform.sizeDelta = new Vector3(Size.x, Size.y, 1);
            }
        }

        public void UpdateObjectPosition()
        {
            if (Object != null && Object.transform.localPosition != new Vector3(Position.x, Position.y, 0))
            {
                Position = ConvertVectorToUniversalDim(Position);
                RectTransform.position = Position;
            }
        }

        public void UpdateStatus(bool activated)
        {
            if(Object != null) Object.SetActive(activated);
        }

        public void End()
        {
            try
            {
                UnityEngine.Object.Destroy(Object);
            }
            catch(Exception e) 
            {   
                RpgClass.LOGGER.Error(e.ToString());
            }
        }

        protected Vector2 ConvertVectorToUniversalDim(Vector2 old)
        {
            return new(old.x * Screen.width / 16, old.y  * Screen.height / 9); // Assuming the screen is 16:9 ratio
        }

        protected float ConvertFloatToUniversalDim(float old)
        {
            return old * Screen.width / 16f; // Assuming the screen is 16:9 ratio
        }
    }   
}