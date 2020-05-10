using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using TMPro;

public class LobbyController : MonoBehaviour
{
    public GameEvent startGame, allPlayersReady;
    public GameObjectRuntimeSet players;
    public List<GameObject> playerUIs = new List<GameObject>();
    public TextMeshProUGUI countdownText;

    int playersReady = 0;
    int countdownSeconds = 5;

    public void AssignPlayerPanel ()
    {
        StopAllCoroutines();
        countdownText.gameObject.SetActive(false);
        var ui = playerUIs[0];
        PlayerInput.all[PlayerInput.all.Count - 1].uiInputModule = ui.GetComponent<InputSystemUIInputModule>();
        ui.GetComponent<MultiplayerEventSystem>().playerRoot.SetActive(true);
        playerUIs.Remove(ui);
    }

    public void PlayerReadyUp ()
    {
        playersReady++;

        if (playersReady == players.Items.Count)
        {
            allPlayersReady.Raise();
            StartCoroutine(Countdown());
        }
    }

    public void PlayerNotReady ()
    {
        playersReady--;
        StopAllCoroutines();
    }

    IEnumerator Countdown ()
    {
        var seconds = countdownSeconds;

        while (seconds > 0)
        {
            countdownText.text = seconds.ToString();
            yield return new WaitForSeconds(1f);
            seconds--;
        }

        startGame.Raise();
    }

}
