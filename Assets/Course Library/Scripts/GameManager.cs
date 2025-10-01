using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;

	public bool isGameActive;

	private int score;
    private float spawnRate = 3.0f;

    public Button restartButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        StartCoroutine(SpawnTarget());
		score = 0;
		UpdateScore(0);
		gameOverText.gameObject.SetActive(false);
		isGameActive = true;
    }

    IEnumerator SpawnTarget() {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
			UpdateScore(5);
        }
    }

	public void UpdateScore(int addValue){
		score += addValue;
		scoreText.text = "Score: " + score;
	}

	public void GameOver() {
		gameOverText.gameObject.SetActive(true);
		restartButton.gameObject.SetActive(true);
		isGameActive = false;
	}

	public void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
