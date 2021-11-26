using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    private float waveCountDown = 3;
    public int enemiesMax;
    public Transform[] SpawnPoints;
    public GameObject enemyPrefab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartButton;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        InvokeRepeating("Spawning",0f,3.0f);
    
    }

    // Update is called once per frame
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Spawning()
    {
        if(enemiesMax > 0)
        {
            Instantiate(enemyPrefab, SpawnPoints[0].transform.position, Quaternion.identity); 
        }  
        --enemiesMax;
    }
    
}
