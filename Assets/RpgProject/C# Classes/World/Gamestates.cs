using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState 
{
    PLAYING,                // 
    BUSY,                   //
    DEAD,                   //


    /*===================( MULTIPLAYER )===================*/

    CLIENT_CONNECTING,      // Client trying to connect to server
    CLIENT_DISCONNECTING,   // Client disconnecting from server

    SERVER_SYNCING,         // Server sending server save data to players
    SERVER_BUSY,            // Server doesnt respond
    SERVER_PLAYING,         // Normal
    SERVER_CLOSING,         // When the server is closing

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