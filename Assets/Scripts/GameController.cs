using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public GameObjectCollection players;
    public GameObject playerPrefab;

    void Start()
    {
        for (int i = 0; i < players.Count; i++)
        {
            var player = Instantiate(playerPrefab, new Vector3(-3f + (i * 2) , 0), Quaternion.identity);
            players[i].GetComponent<PlayerInput>().SwitchCurrentActionMap("Game");
            player.GetComponent<Renderer>().material.color = Random.ColorHSV();
            //Using RuntimeSet of Players to assign rigidbody
            players[i].GetComponent<PlayerController>().rb = player.GetComponent<Rigidbody>();
        }
    }
}
