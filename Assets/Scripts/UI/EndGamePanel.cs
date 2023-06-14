using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGamePanel : BasePanel
{

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI buttonText;



    private CanvasGroup canvasGroup;

    protected override void Awake()
    {
        base.Awake();
        canvasGroup = GetComponentInChildren<CanvasGroup>(true);
    }
    public override void Open()
    {
        base.Open();
        canvasGroup.alpha = 0f;
        StartCoroutine(Fade(1f));
    }
    private IEnumerator Fade(float targetValue)
    {
        while (canvasGroup.alpha != targetValue) { 
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, targetValue, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        
        }
    }
    public void Setup(bool playerDied)
    {
        if (playerDied == true)
        {
            titleText.text = "Oh No!";
            buttonText.text = "RESTART";
        }
        else
        {
            titleText.text = "You Did It!";
            buttonText.text = "CONTINUE";
        }

        finalScoreText.text = Player.playerInstance.score.ToString();

        if (playerDied == true)
        {
            Player.playerInstance.score = 0;
        }

        
    }

    public void OnRestartClicked()
    {
        GameManager.gameManagerInstance.StartGame();
        Close();
    }



}
