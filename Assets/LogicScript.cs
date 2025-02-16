using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highscoreText;
    public GameObject gameOverScreen;
    public AudioSource background_music;
    public AudioSource score_sound;
    public int highscore;

    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        background_music = audioSources[0];
        score_sound = audioSources[1];
        background_music.Play();

        //PlayerPrefs.SetInt("Highscore", 0);
        highscore = PlayerPrefs.GetInt("Highscore",0);
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        score_sound.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {   
        if (playerScore > highscore)
        {
            PlayerPrefs.SetInt("Highscore",playerScore);
            highscoreText.text = "Highscore: " + playerScore.ToString();
            Debug.Log("Neuer Highscore gespeichert: " + playerScore);
        }

        gameOverScreen.SetActive(true);
    }
}
