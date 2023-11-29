using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RpgProject.FrameworkV2.Handlers
{
    public class InputHandler : MonoBehaviour
    {
        private List<InputEvent> PLAYING_KEYEVENT = new List<InputEvent>();
        private bool isInputProcessing = false;

        public void Update()
        {
            if (Input.anyKeyDown && !isInputProcessing)
            {
                switch (RpgClass.MODE_ETA)
                {
                    case GAMEMODE.PLAYING:
                        StartCoroutine(HandleKey_PlayMode(GetPressedKey()));
                        break;

                    case GAMEMODE.INTERFACE:
                        StartCoroutine(HandleKey_InterfaceMode(GetPressedKey()));
                        break;

                    default:
                        break;
                }
            }
        }

        public void addListener(GAMEMODE eta, InputEvent input)
        {
            switch (eta)
            {
                case GAMEMODE.PLAYING:
                    PLAYING_KEYEVENT.Add(input);
                    break;
                    

                default:
                    PLAYING_KEYEVENT.Add(input);
                    break;
            }
        }

        protected IEnumerator HandleKey_PlayMode(KeyCode key)
        {
            isInputProcessing = true;

            foreach (InputEvent input in PLAYING_KEYEVENT)
                if (input.KEY == key)
                    input.ACTION.Invoke();

            yield return null;

            isInputProcessing = false;
        }

        protected IEnumerator HandleKey_InterfaceMode(KeyCode key)
        {
            isInputProcessing = true;
            yield return RpgClass.INTERFACE_BUFFER[RpgClass.INTERFACE_BUFFER.Count-1].PushKey(key);

            yield return null;
            isInputProcessing = false;
        }

        protected KeyCode GetPressedKey()
        {
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                if (Input.GetKeyDown(keyCode))
                    return keyCode;

            return KeyCode.None;
        }
    }

    public class InputEvent
    {
        public KeyCode KEY { get; }
        public UnityAction ACTION { get; }

        public InputEvent(KeyCode key, UnityAction action)
        {
            KEY = key;
            ACTION = action;
        }
    }
}
