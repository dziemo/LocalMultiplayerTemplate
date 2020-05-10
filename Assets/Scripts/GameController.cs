using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObjectRuntimeSet players;
    public GameObject playerPrefab;
    void Start()
    {
        for (int i = 0; i < players.Items.Count; i++)
        {
            var player = Instantiate(playerPrefab, new Vector3(-3f + (i * 2) , 0), Quaternion.identity);
            player.GetComponent<Renderer>().material.color = Random.ColorHSV();
            players.Items[i].GetComponent<PlayerController>().rb = player.GetComponent<Rigidbody>();
        }
    }
}
