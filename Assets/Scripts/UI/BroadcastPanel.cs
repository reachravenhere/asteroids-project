using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BroadcastPanel : BasePanel
{

    public TextMeshProUGUI broadcastText;

    public void ShowMessage(string message, float time = 3f)
    {
        StartCoroutine(ShowMessageCoroutine(message, time));
    }

    public IEnumerator ShowMessageCoroutine(string message, float time = 3f)
    {
        broadcastText.text = message;

        yield return new WaitForSeconds(time);

        broadcastText.text = "";

    }

}
