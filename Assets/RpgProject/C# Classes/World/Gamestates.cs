using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    PLAYING,
    BUSY
}

public class Gamestates : MonoBehaviour {
    public static GameState CurrentState = GameState.PLAYING;

    public static void set(GameState state)
    {
        CurrentState = state;
    }

    public static GameState get()
    {
        return CurrentState;
    }
}