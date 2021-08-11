using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager Is Null");
            }
            return _instance;
        }
        
    }

    public bool hasKey { get; set;}
    public bool hasBootsOfFlight { get; set; }
    public bool hasFlameSword { get; set; }

    public bool youWin { get; set; }

    public bool gameOver { get; set; }

    public Player _player { get; private set; }

    private void Awake()
    {
        _instance = this;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Update()
    {
        if(gameOver == true)
        {
            SceneManager.LoadScene(0);
        }
    }

}
