using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private GameObject levelCompletePanel;

    [SerializeField] private Slider progressBar;
    [SerializeField] private Text levelText;


    // Start is called before the first frame update
    void Start()
    {
        progressBar.value = 0;

        gamePanel.SetActive(false);
        gameoverPanel.SetActive(false);

        levelText.text = "Level " + (ChunkManager.instance.GetLevel() + 1);

        GameManager.onGameStateChanged += GameStateChangedCallback;
    }


    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;

    }
    // Update is called once per frame
    void Update()
    {
        UpdateProgressBar();
    }

    public void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Gameover)
            ShowGameOver();
        if (gameState == GameManager.GameState.LevelComplete)
            showLevelComplete();
    }

    public void PlayButtonPressed()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Game);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void RetryButtomPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowGameOver()
    {
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(true);
    }

    public void showLevelComplete()
    {

        gamePanel.SetActive(false);
        levelCompletePanel.SetActive(true);
    }


    public void UpdateProgressBar()
    {
        if (!GameManager.instance.IsGameState())
            return;

        float progress = PlayerController.instance.transform.position.z / ChunkManager.instance.GetFinishZ();
        progressBar.value = progress;
    }
}
