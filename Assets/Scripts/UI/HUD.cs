using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : BasePanel
{

    private TextMeshProUGUI scoreText;
    public bool gameStarted;

    protected override void Awake()
    {
        base.Awake();
        scoreText = GetComponentInChildren<TextMeshProUGUI>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && gameStarted == false)
        {
            gameStarted = true;
            GameManager.gameManagerInstance.StartGame();
            Debug.Log("Starting Game");
        }
    }

    public void SetScoreText(string text)
    {
        scoreText.text = text;
    }

    public void ResetScore()
    {
        scoreText.text = "Score: " + Player.playerInstance.score;
    }

}
