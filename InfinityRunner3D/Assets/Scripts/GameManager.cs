using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int ScoreCoin;
    public static GameManager inst;
    public GameObject GOpanel;
    public GameObject bottonPause;
    public Text CoinPoints;

    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GOpanel.SetActive(true);
        bottonPause.SetActive(false);
    }

    public void RestarGame()
    {
        SceneManager.LoadScene(1);
    }

    public void incrementScore()
    {
        ScoreCoin++;
        CoinPoints.text = "Coins: " + ScoreCoin;
    }    
}
