using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager myInstance;
    //public TextMeshProUGUI scoreText;
    //public int score = 0;
    public GameObject gameOverPanel;
    public GameObject startGamePanel;
    public GameObject scoreScreen;




    [SerializeField] TMP_Text scoreDisplayText;
    [SerializeField] TMP_Text highScoreDisplayText;
    private void Awake()
    {
        myInstance = this;
    }

    void Start()
    {
        Time.timeScale = 0;
        startGamePanel.SetActive(true);
        gameOverPanel.SetActive(false);


        
    }
    void Update()
    {
        //scoreText.text = score.ToString();

        scoreDisplay();
        highScoreDisplay();
    }
    public void StartGame()
    {

        startGamePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ResetLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("OYUNDAN ÇIKILDI");
    }


    private void scoreDisplay()
    {
        scoreDisplayText.text = PlayerController.score.ToString();
    }

    private void highScoreDisplay()
    {
        highScoreDisplayText.text = PlayerPrefs.GetInt("highScore").ToString();
    }
}
