using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using RpgProject.FrameworkV2.Handlers;
using System.Collections.Generic;
using UnityEngine.UI;

namespace RpgProject.FrameworkV2
{
    class Drawable
    {
        private DrawableObject[] DrawableObjects; 
        public GameObject Object;
        public CanvasGroup Canvas;
        public RectTransform RectTransform;

        public IEnumerator OnLoad;
        public IEnumerator OnEnd;
        public List<InputEvent> InputEvents;

        public long NameIdentifier;

        public Drawable(IEnumerator onLoad, IEnumerator onEnd, float DefaultCanvasOpacity, List<InputEvent> inputEvents, params DrawableObject[] drawableObjects)
        {
            NameIdentifier = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Object = new GameObject($"{NameIdentifier}");

            Object.transform.SetParent(GameObject.FindObjectOfType<Canvas>().transform, false);
            RectTransform = Object.AddComponent<RectTransform>();

            RectTransform.sizeDelta = new Vector3(Screen.width, Screen.height, 0);
            RectTransform.position =  new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Canvas = Object.AddComponent<CanvasGroup>();
            Canvas.alpha = DefaultCanvasOpacity;

            OnLoad = onLoad;
            OnEnd = onEnd;
            InputEvents = inputEvents;

            RpgClass.instance.StartCoroutine(CreateContents(drawableObjects));

            DrawableObjects = drawableObjects;

            RpgClass.INTERFACE_BUFFER.Add(this);
        }

        public IEnumerator CreateContents(params DrawableObject[] drawableObjects)
        {
            if(drawableObjects != null)
                foreach (DrawableObject child in drawableObjects)
                    child?.CreateGameObject(Object);

            while (OnLoad.MoveNext())
                yield return null;
        }

        public IEnumerator PushKey(KeyCode key)
        {
            if(InputEvents != null)
            {
                foreach(InputEvent input in InputEvents)
                    if(input.KEY == key)
                        input.ACTION.Invoke();
            }
                        
            yield return null;
        }

        public DrawableObject Find(string name)
        {
            if (DrawableObjects != null)
                foreach (DrawableObject drawableObject in DrawableObjects)
                    if (drawableObject.Object != null && drawableObject.Object.name == name)
                        return drawableObject;
                        
            return null;
        }

        public void End()
        {
            if(Object != null)
                RpgClass.instance.StartCoroutine(DestroySelf());
        }
        
        public void AdjustAlpha(int i)
        {
            if(Canvas != null || i !< 0)
                Canvas.alpha = i;
        }

        public IEnumerator Fade(float startAlpha, float targetAlpha, float duration)
        {
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                Canvas.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            Canvas.alpha = targetAlpha;
        }

        public IEnumerator Left(float startX, float targetX,float duration)
        {
            float elapsedTime = 0f;
            Vector2 startPos = new(startX, RectTransform.anchoredPosition.y);
            Vector2 targetPos = new(targetX, RectTransform.anchoredPosition.y);

            while (elapsedTime < duration)
            {
                RectTransform.anchoredPosition = new Vector2(Mathf.Lerp(startPos.x, targetPos.x, elapsedTime / duration), startPos.y);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            RectTransform.anchoredPosition = targetPos;
        }


        private IEnumerator DestroySelf()
        {

            while (OnEnd.MoveNext())
                yield return null;

            RpgClass.LOGGER.Log($"Destroying {NameIdentifier}");
            GameObject.Destroy(Object);

            RpgClass.INTERFACE_BUFFER.Remove(this);
            yield return null;
        }
    }
}