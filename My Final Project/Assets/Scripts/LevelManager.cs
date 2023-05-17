using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject TitlePanel;
    public GameObject WinnerPanel;
    public GameObject GameOverPanel;

    public TextMeshProUGUI FoodCountText;

    [SerializeField] private bool _isGameActive = false;
    public int _foodCollected = 0;

void Awake()
     {
         Instance = this;
     }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        FoodCountText.text = _foodCollected.ToString();
    }

    public bool StartGame()
    {
        _isGameActive = true;
        return _isGameActive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReplayButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _isGameActive = true;
    }

    public void PlayButtonPressed()
    {
        Time.timeScale = 1;
        TitlePanel.SetActive(false);
        _isGameActive = true;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }

    public void Winner()
    {
        Time.timeScale = 0; 
        WinnerPanel.SetActive(true);
        
    }

    public void UpdateLevelFoodCount(int amount)
    { 
        _foodCollected += amount;
        FoodCountText.text = _foodCollected.ToString();
        if(_foodCollected >= 10)
        {
            Winner();
        }
    }
}
