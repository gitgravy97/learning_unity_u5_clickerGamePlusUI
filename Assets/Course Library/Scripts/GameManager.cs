using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;

	private int score;
    private float spawnRate = 3.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        StartCoroutine(SpawnTarget());
		score = 0;
		UpdateScore(0);
		gameOverText.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget() {
        while (true)
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
	}
}
