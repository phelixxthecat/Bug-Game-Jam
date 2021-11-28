using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int health;
    private float waveCountDown = 3;
    public int enemiesMax;
    public Transform[] SpawnPoints;
    public GameObject enemyPrefab;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button startButton;
    private Player MyPlayer;
    public bool isGameActive = false;

    // Start is called before the first frame update
    void Start()
    {
        MyPlayer = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        health = MyPlayer.health;
        healthText.text = "Health " + health;
        GameOver();
    }

    public void GameOver()
    {
        if(health == 0)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameActive = false;
        }
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
    
    public void StartGame()
    {
        isGameActive = true;
        InvokeRepeating("Spawning",0f,3.0f);
        startButton.gameObject.SetActive(false);
    }
}
