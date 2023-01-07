using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState 
{
    /*===================( SINGLEPLAYER )===================*/

    PLAYING,                // Normal state, General Entity can moves
    BUSY,                   // Specific entity's can only move
    DEAD,                   // Game stopped and waiting to player respawn


    /*===================( MULTIPLAYER )===================*/

    OFFLINE,                // When the client is playing in singleplayer

    CLIENT_CONNECTING,      // Client trying to connect to server
    CLIENT_DISCONNECTING,   // Client disconnecting from server
    CLIENT_DEAD,            // When player is dead

    SERVER_SYNCING,         // Server sending server save data to players
    SERVER_BUSY,            // Server doesnt respond
    SERVER_PLAYING,         // Normal
    SERVER_CLOSING,         // When the server is closing

}

public class Gamestates : MonoBehaviour 
{
    public static GameState CurrentState = GameState.PLAYING;
    public static GameState ServerState = GameState.OFFLINE;

    public static void set(GameState state)
    {
        CurrentState = state;
    }

    public static GameState get()
    {
        return CurrentState;
    }

     public static void Server__set(GameState state)
    {
        CurrentState = state;
    }

    public static GameState Server__get()
    {
        return CurrentState;
    }
}