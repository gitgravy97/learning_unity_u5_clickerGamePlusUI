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
    public GameObject titleScreen;
    
    public void StartGame(int difficulty) {
	    spawnRate /= difficulty;
	    isGameActive = true;
	    score = 0;
	    StartCoroutine(SpawnTarget());
	    UpdateScore(0);
	    titleScreen.gameObject.SetActive(false);
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
