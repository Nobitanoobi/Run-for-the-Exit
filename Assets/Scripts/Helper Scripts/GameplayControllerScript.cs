using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameplayControllerScript : MonoBehaviour
{

    public static GameplayControllerScript instance;
    private Text coinText, healthText, timerText;

    private float timerValue = 99;
    private float coinValue = 0;
    [HideInInspector]
    public bool isPlayerAlive = false;

    public GameObject gameoverPanel;


    void Awake()
    {
        MakeInstance();
        isPlayerAlive = true;
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        coinText = GameObject.Find("CoinText").GetComponent<Text>();
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        coinText.text = "Coins: " + coinValue;
        timerText.text = "Timer: " + timerValue.ToString("F0");
    }

    void Start()
    {
        gameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void CountDown()
    {
        timerValue -= Time.deltaTime;
        if (timerValue < 0)
        {
            timerValue = 0;
            Gameover();
        }
        else
        {
            timerText.text = "Timer: " + timerValue.ToString("F0");
        }
        
        
    }

    public void CollectedCoins()
    {
        coinValue++;
        coinText.text = "Coins: " + coinValue;
    }

    public void DisplayHealth(int healthValue)
    {
        healthText.text = "Health: " + healthValue;
    }

    public void Gameover()
    {
        gameoverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(currentScene + 1);
        }
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
}
