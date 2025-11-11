using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _endScreen.RestartButtonClicked += OnRestartButtonClicked;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _endScreen.RestartButtonClicked -= OnRestartButtonClicked;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }

    private void OnRestartButtonClicked()
    {
        _endScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
        _enemySpawner.ReleaseAll();
        _bulletSpawner.ReleaseAll();
        _scoreCounter.ResetValue();
    }

    private void OnPlayButtonClicked()
    {
        _startScreen.Close();
        StartGame();
    }
}
