using UnityEngine;
using UnityEngine.UI;
public class GameplayControllerScript : MonoBehaviour
{

    public static GameplayControllerScript instance;
    private Text coinText, healthText, timerText;

    private float timerValue = 99;
    private float coinValue = 0;
    [HideInInspector]
    public bool isPlayerAlive = false;


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
        timerText.text = "Timer: " + timerValue.ToString("F0");
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
}
