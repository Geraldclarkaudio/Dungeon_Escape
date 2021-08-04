using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        _instance = this;
    }


}
