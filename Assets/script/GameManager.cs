using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startButton;
    public Player player;

    public bool gameIsPause;

    public Text gameOverCountdown;
    public float countTimer;

    public Text playerScoure;
    public float scoure;
    // Start is called before the first frame update
    void Start()
    {
        gameIsPause = false;
        scoure = 0; 
        gameOverCountdown.gameObject.SetActive(false);
        countTimer = 3;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            gameOverCountdown.gameObject.SetActive(true);
            countTimer -= Time.unscaledDeltaTime;
        }

        gameOverCountdown.text = "Restarting in " + (countTimer).ToString("0");

        playerScoure.text = $"Scoure: {(scoure).ToString("0")}";

        if (player.scouceUp)
        {
            scoure++;
            playerScoure.text = $"Scoure: {(scoure).ToString("0")}";
            player.scouceUp = false;
        }
        ;

        if (countTimer < 0)
        {
            RestartGame();
        }
    }
    public void StartGame()
    {
        startButton.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        EditorSceneManager.LoadScene(0);
    }
    public void PauseGame()
    {
        gameIsPause = !gameIsPause;
        if(gameIsPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
