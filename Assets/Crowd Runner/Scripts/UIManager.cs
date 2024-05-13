using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Slider progressBar;

    // Start is called before the first frame update
    void Start()
    {
        progressBar.value = 0;

        gamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgressBar();
    }

    public void PlayButtonPressed()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Game);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void UpdateProgressBar()
    {
        if (!GameManager.instance.IsGameState())
            return;

        float progress = PlayerController.instance.transform.position.z / ChunkManager.instance.GetFinishZ();
        progressBar.value = progress;
    }
}
