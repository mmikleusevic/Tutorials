using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button replayButton;
    [SerializeField] private GameObject titleScreen;

    private int score;
    private float spawnRate = 1f;
    public bool isGameActive;

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        replayButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        titleScreen.gameObject.SetActive(true);
    }

    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);

        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(score);
    }
}
