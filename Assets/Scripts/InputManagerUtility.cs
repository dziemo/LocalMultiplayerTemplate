using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerUtility : MonoBehaviour
{
    public GameEvent playerJoinedEvent;
    public GameObjectRuntimeSet players;

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        //Add player to RuntimeSet
        players.Add(playerInput.gameObject);
        playerJoinedEvent.Raise();
    }

    private void OnDisable()
    {
        players.Items.Clear();
    }
}
