using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public GameObject gameOverText;
    public Text highScoreText;
    public Text scoreText;
    public Text coinsText;
    public bool gameOver = false;
    public float scrollSpeed;

    private PlayerProgress playerProgress;
    private int score = 0;

	// Use this for initialization
	void Awake () {
		
        if(instance == null){

            instance = this;
        }else if(instance != this){

            Destroy(gameObject);
        }

        LoadPlayerProgress();
        SetCoinsText();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(gameOver && (Input.GetMouseButtonDown(0) || Input.anyKeyDown)){

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void BirdScored(){

        if(gameOver){

            return;
        }
        score++;
        SetScoreText();
    }

    void SetCoinsText(){

        coinsText.text = "Coins: " + playerProgress.coins.ToString();
    }

    void SetScoreText(){

        scoreText.text = "Score: " + score.ToString();
    }

    public void SetHighScoreText(){

        highScoreText.text = "High Score: " + playerProgress.highScore.ToString();
    }

    public void BirdDied(){

        SubmitScore();
        SetHighScoreText();
        SaveCoins();

        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void SubmitScore(){

        if(score > playerProgress.highScore){

            playerProgress.highScore = score;
            SaveHighScore();
        }
    }

    public void LoadPlayerProgress(){

        playerProgress = new PlayerProgress();

        if(PlayerPrefs.HasKey("highScore")){

            playerProgress.highScore = PlayerPrefs.GetInt("highScore");
        }
        if(PlayerPrefs.HasKey("coins")){

            playerProgress.coins = PlayerPrefs.GetInt("coins");
        }
    }

    public void SaveHighScore(){

        PlayerPrefs.SetInt("highScore", playerProgress.highScore);
    }

    public void PickUpCoin(){
        
        playerProgress.coins++;
        SetCoinsText();
    }

    public void SaveCoins(){

        PlayerPrefs.SetInt("coins", playerProgress.coins);
    }
}
