using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [Header(" Sounds ")]
    [SerializeField] private AudioSource doorHitSound;
    [SerializeField] private AudioSource runnerDieSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameoverSound;

    // Start is called before the first frame update
    void Start()
    {
        PlayerDetection.onDoorsHit += PlayDoorHitSound;

        GameManager.onGameStateChanged += GameStateChangedCallback;

        Enemy.onRunnerDied += PlayRunnerDieSound;
    }

    private void OnDestroy()
    {
        PlayerDetection.onDoorsHit -= PlayDoorHitSound;

        GameManager.onGameStateChanged -= GameStateChangedCallback;

        Enemy.onRunnerDied -= PlayRunnerDieSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.LevelComplete)
            levelCompleteSound.Play();
        else if (gameState == GameManager.GameState.Gameover)
            gameoverSound.Play();
    }

    private void PlayDoorHitSound()
    {
        doorHitSound.Play();
    }

    private void PlayRunnerDieSound()
    {
        runnerDieSound.Play();
    }
}
