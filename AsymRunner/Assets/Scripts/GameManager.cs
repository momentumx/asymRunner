using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    [Header("Game States")]
    public bool isStart = true;
    public bool inGame = false;
    public bool isOver;

    [Header("UI Elements")]
    public GameObject startScreen;
    public GameObject inGameScreen;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    [Header("Animations")]
    public Animator transition;
    public float transitionTime = 1;

    [Header("Variables")]
    public int _coins;
    public int coins;
    public int score;
    public int highScore;
    

    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            enabled = false;
        }
        highScoreText.text = "High Score:" + PlayerPrefs.GetInt("highscore");
        coinText.text = "Coins:" + PlayerPrefs.GetInt("coins");
        coins = PlayerPrefs.GetInt("coins");
    }

    public void Start()
    {
        Time.timeScale = 0;
        _coins = coins;
    }

    public void Update()
    {
        score = Mathf.RoundToInt(Time.time/1.5f);
        scoreText.text = "Score:" + score;

        if(_coins != coins)
        {
            coinText.text = "Coins:" + coins;
            PlayerPrefs.SetInt("coins", coins);
            _coins = coins;
        }


        if (score > PlayerPrefs.GetInt("highscore"))
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
            highScoreText.text = "High Score:" + PlayerPrefs.GetInt("highscore");

        }
    }

    public void MenuButtonClicked()
    {
        Time.timeScale = 1;
        //TODO call audio fade.
        LoadMenu();
    }


    public void LoadMenu() { StartCoroutine(LoadLevel(0)); }


    IEnumerator LoadLevel(int sceneIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }

   public void AddCoin()
    {
        coins = PlayerPrefs.GetInt("coins") + 1;
        coinText.text = "Coins:" + coins;
        PlayerPrefs.SetInt("coins", coins);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        inGameScreen.SetActive(false);
    }

    public void Reset()
    {
        score = 0;
        SceneManager.LoadScene(1);
    }
    public void StartGame()
    {
        isStart = false;
        inGame = true;
        startScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        inGameScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
}

