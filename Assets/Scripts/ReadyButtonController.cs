using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadyButtonController : MonoBehaviour
{
    bool isReady = false;

    public GameEvent playerReady, playerNotReady;

    public TextMeshProUGUI buttonText;
    
    public Image buttonImage;
    

    public void ChangeStatus ()
    {
        isReady = !isReady;

        if (isReady)
        {
            buttonText.text = "Ready";
            buttonImage.color = Color.green;
            playerReady.Raise();
        } else
        {
            buttonText.text = "Not Ready";
            buttonImage.color = Color.red;
            playerNotReady.Raise();
        }
    }

}
