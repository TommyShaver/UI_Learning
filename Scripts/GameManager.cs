using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText, _livesText, gameOverText, _volumeText;
    public Button resetButton;
    public GameObject _titleScreen, _pauseScreen;

    public bool isGameActive = true;
    public bool _paused;
    public int _lives = 3;
    

    private int score;
    private float spawnRate = 3;
    
       


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void ChangePaused()
    {
        if(!_paused)
        {
            _paused = true;
            _pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _paused = false;
            _pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
          
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }
    public void UpdateLives()
    {
        _livesText.text = "Lives : " + _lives;
    }
    public void GameOver()
    {
        resetButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        _titleScreen.gameObject.SetActive(false);
        _volumeText.gameObject.SetActive(false);
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
    private void Update()
    {
        UpdateLives();
        if(Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }
}
