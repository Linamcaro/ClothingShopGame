using System;
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
            return _instance;
        }
    }



    [SerializeField] private int currentCoins;

    public event EventHandler OnCoinAmountChanged;

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }

    }


    public void ReduceCoins(int coins)
    {
        
        currentCoins -= coins;
        OnCoinAmountChanged?.Invoke(this, EventArgs.Empty);

    }

    public int GetCoinsAmount()
    {
        return currentCoins;
    }

}
