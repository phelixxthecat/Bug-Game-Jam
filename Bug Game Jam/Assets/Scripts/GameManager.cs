using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int health;
    public int bossesDefeated = 0;
    public GameObject player;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI congratsText;
    public Button restartButton;
    public Button startButton;
    public Player playerScript;
    public bool isGameActive = false;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        health = playerScript.health;
        Win();
        GameOver();
    }

    public void GameOver()
    {
        if(health <= 0)
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

    
    
    public void StartGame()
    {
        isGameActive = true;
        startButton.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
    }

    public void Win()
    {
        if(bossesDefeated == 3)
        {
            congratsText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameActive = false;
        }
        
    }
}
